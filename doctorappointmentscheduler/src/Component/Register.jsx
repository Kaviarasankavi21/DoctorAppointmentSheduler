import React, { useState } from "react";
import { Form, Button, Container, Row, Col, Card, Toast, ToastContainer } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";

function Register() {
  const navigate = useNavigate();

  const [toast, setToast] = useState({ show: false, message: "", bg: "" });
  const [phoneError, setPhoneError] = useState(""); // <--- declare phoneError
  const showToast = (message, bg = "success") => {
    setToast({ show: true, message, bg });
    setTimeout(() => setToast({ show: false, message: "", bg: "" }), 3000);
  };

  const titleOptions = [
    { id: "61b1d8a0-502c-4164-8c10-71bed476b386", name: "Mr" },
    { id: "f88e55a0-cfdd-4309-8a71-ce849b462de", name: "Mrs" },
    { id: "94f1804b-fed5-4da3-afc8-85356e677aef", name: "Ms" },
    { id: "e2013894-e7e8-4943-9ef9-28f3bfe56280", name: "Dr" },
    { id: "71ff3081-3926-4113-90d2-cb8a68208198", name: "Prof" },
  ];

  const occupationOptions = [
    { id: "9ab66c29-cb08-40d8-8290-49bce85a2f9f", name: "Student" },
    { id: "d1a00cf5-5643-435f-83c2-0bdbc3ae3f12", name: "Employee" },
    { id: "35a26091-0172-4487-aa89-13aeba419ad4", name: "Business" },
    { id: "67e0fc61-df0c-49ac-98af-30781cdfd6d3", name: "Retired" },
    { id: "a0193a0c-fc03-48e1-9fe9-00cf9347f4ae", name: "Other" },
  ];

  const religionOptions = [
    { id: "6dfe00f6-4404-4d99-ac83-0c1674feabf9", name: "Hindu" },
    { id: "70a84839-072c-417d-a2d7-3d4787151ec8", name: "Christian" },
    { id: "59ce2442-93c1-4155-b25e-f9b00aea4064", name: "Muslim" },
    { id: "99e1c1ce-06f6-4630-b9e5-73f8ed289f49", name: "Sikh" },
    { id: "6bde0ff9-d86d-455a-8347-8c0b14128500", name: "Other" },
  ];

  const maritalStatusOptions = [
    { id: "80fe2a2a-ad48-4caa-9332-e48556eb44f1", name: "Single" },
    { id: "57f41d04-cb70-4426-bb78-5d5474a89e56", name: "Married" },
    { id: "9a4ea77a-d761-42b0-a8e9-8fdf960274c6", name: "Divorced" },
    { id: "be2f3d04-b7b2-4b4e-9dad-af4d4bd9530b", name: "Widowed" },
    { id: "a3b7d431-9f24-4c8e-bd86-d4318e681400", name: "UnMarried" },
  ];

  const [formData, setFormData] = useState({
    titleId: "",
    name: "",
    dob: "",
    age: "",
    Username: "",
    occupationId: "",
    gender: "",
    maritalStatusId: "",
    religionId: "",
    email: "",
    password: "",
    confirmPassword: "",
    phoneNumber: "",
    address: "",
  });

  // --- Phone validation method ---
  const validatePhoneNumber = (number) => {
    // Indian mobile rule: 10 digits and starts with 6-9
    const phoneRegex = /^[6-9]\d{9}$/;
    if (!number) return "Phone number is required";
    if (!phoneRegex.test(number)) return "Enter a valid 10-digit mobile number";
    return "";
  };

  const handleChange = (e) => {
    const { name, value } = e.target;

    if (name === "dob") {
      const today = new Date();
      const birthDate = new Date(value);
      let age = today.getFullYear() - birthDate.getFullYear();
      const m = today.getMonth() - birthDate.getMonth();
      if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) age--;
      setFormData({ ...formData, [name]: value, age });
    } else if (name === "phoneNumber") {
      // keep only digits and limit to 10
      let cleanedValue = value.replace(/\D/g, "");
      if (cleanedValue.length > 10) cleanedValue = cleanedValue.slice(0, 10);

      setFormData({ ...formData, [name]: cleanedValue });

      // validate immediately (show error while typing)
      const validationMessage = cleanedValue ? validatePhoneNumber(cleanedValue) : "";
      setPhoneError(validationMessage);
    } else {
      setFormData({ ...formData, [name]: value });
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    // phone validation before submit
    if (!formData.phoneNumber) {
      setPhoneError("Phone number is required");
      showToast("Please enter a valid phone number!", "danger");
      return;
    }
    const phoneValidation = validatePhoneNumber(formData.phoneNumber);
    if (phoneValidation) {
      setPhoneError(phoneValidation);
      showToast(phoneValidation, "danger");
      return;
    }

    if (formData.password !== formData.confirmPassword) {
      showToast("Passwords do not match!", "danger");
      return;
    }

    const nameParts = formData.name.trim().split(" ");
    const firstName = nameParts[0] || "";
    const lastName = nameParts.slice(1).join(" ") || "";

    const payload = {
      FirstName: firstName,
      LastName: lastName,
      DateOfBirth: formData.dob ? new Date(formData.dob).toISOString() : null,
      Gender: formData.gender,
      Password: formData.password,
      Username: formData.Username || null,
      TitleId: formData.titleId || null,
      OccupationId: formData.occupationId || null,
      ReligionId: formData.religionId || null,
      MaritalStatusId: formData.maritalStatusId || null,
      PhoneNumber: formData.phoneNumber || null,
      Address: formData.address || null,
      Role: "Patient",
    };

    console.log("Payload:", payload);

    try {
      const response = await fetch("http://localhost:5185/api/User/register", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(payload),
      });

      if (!response.ok) {
        const errorData = await response.json().catch(() => ({}));
        console.error("Backend error:", errorData);
        showToast(errorData.message || "Registration failed!", "danger");
        return;
      }

      const data = await response.json();
      console.log("API Response:", data);
      showToast("Registration successful!", "success");
      navigate("/appointments");
    } catch (error) {
      console.error("Error:", error);
      showToast("Something went wrong. Please try again.", "danger");
    }
  };

  return (
    <div className="registerbg d-flex justify-content-center align-items-center" style={{ minHeight: "100vh" }}>
      {/* Toast container (shows toasts) */}
      <ToastContainer className="p-3" position="top-end">
        <Toast
          onClose={() => setToast({ show: false, message: "", bg: "" })}
          show={toast.show}
          bg={toast.bg}
          delay={3000}
          autohide
        >
          <Toast.Body>{toast.message}</Toast.Body>
        </Toast>
      </ToastContainer>

      <Container className="d-flex justify-content-center align-items-center" style={{ minHeight: "100vh" }}>
        <Row className="w-100 justify-content-center">
          <Col xs={12} sm={11} md={10} lg={9} xl={8}>
            <Card className="register register-clarity elevated-card bg-transparent overflow-hidden">
              <div className="register-header p-3">
                <h2 className="m-0">Create your account</h2>
              </div>
              <div className="p-3">
                <Form onSubmit={handleSubmit}>
                  <div className="section-title">Basic details</div>
                  <Row>
                    <Col md={3}>
                      <Form.Group className="mb-2">
                        <Form.Label>Title</Form.Label>
                        <Form.Select name="titleId" value={formData.titleId} onChange={handleChange} required>
                          <option value="">Select Title</option>
                          {titleOptions.map((t) => (
                            <option key={t.id} value={t.id}>
                              {t.name}
                            </option>
                          ))}
                        </Form.Select>
                      </Form.Group>
                    </Col>
                    <Col md={9}>
                      <Form.Group className="mb-2">
                        <Form.Label>Full Name</Form.Label>
                        <Form.Control type="text" placeholder="Enter your full name" name="name" value={formData.name} onChange={handleChange} required />
                      </Form.Group>
                    </Col>
                  </Row>

                  <div className="section-title mt-2">Demographics</div>
                  <Row>
                    <Col md={6}>
                      <Form.Group className="mb-2">
                        <Form.Label>Date of Birth</Form.Label>
                        <Form.Control type="date" name="dob" value={formData.dob} onChange={handleChange} required />
                      </Form.Group>
                    </Col>
                    <Col md={3}>
                      <Form.Group className="mb-2">
                        <Form.Label>Age</Form.Label>
                        <Form.Control type="text" value={formData.age || ""} readOnly />
                      </Form.Group>
                    </Col>
                    <Col md={3}>
                      <Form.Group className="mb-2">
                        <Form.Label>Occupation</Form.Label>
                        <Form.Select name="occupationId" value={formData.occupationId} onChange={handleChange} required>
                          <option value="">Select Occupation</option>
                          {occupationOptions.map((o) => (
                            <option key={o.id} value={o.id}>
                              {o.name}
                            </option>
                          ))}
                        </Form.Select>
                      </Form.Group>
                    </Col>
                  </Row>

                  <Row>
                    <Col md={6}>
                      <Form.Group className="mb-2">
                        <Form.Label>Email</Form.Label>
                        <Form.Control type="email" placeholder="Enter email" name="email" value={formData.email} onChange={handleChange} />
                      </Form.Group>
                    </Col>
                    <Col md={6}>
                      <Form.Group className="mb-2">
                        <Form.Label>Phone Number</Form.Label>
                        <Form.Control
                          type="text"
                          placeholder="Enter phone number"
                          name="phoneNumber"
                          value={formData.phoneNumber}
                          onChange={handleChange}
                          isInvalid={!!phoneError}
                          maxLength={10}
                          required
                        />
                        <Form.Control.Feedback type="invalid">{phoneError}</Form.Control.Feedback>
                      </Form.Group>
                    </Col>
                  </Row>

                  <div className="section-title mt-2">Additional info</div>
                  <Row>
                    <Col md={4}>
                      <Form.Group className="mb-2">
                        <Form.Label>Gender</Form.Label>
                        <div className="d-flex flex-wrap gap-3 mt-2">
                          <Form.Check type="radio" id="gender-male" name="gender" value="Male" label="Male" checked={formData.gender === "Male"} onChange={handleChange} required />
                          <Form.Check type="radio" id="gender-female" name="gender" value="Female" label="Female" checked={formData.gender === "Female"} onChange={handleChange} required />
                          <Form.Check type="radio" id="gender-other" name="gender" value="Other" label="Other" checked={formData.gender === "Other"} onChange={handleChange} required />
                        </div>
                      </Form.Group>
                    </Col>
                    <Col md={4}>
                      <Form.Group className="mb-2">
                        <Form.Label>Marital Status</Form.Label>
                        <Form.Select name="maritalStatusId" value={formData.maritalStatusId} onChange={handleChange} required>
                          <option value="">Select Marital Status</option>
                          {maritalStatusOptions.map((m) => (
                            <option key={m.id} value={m.id}>
                              {m.name}
                            </option>
                          ))}
                        </Form.Select>
                      </Form.Group>
                    </Col>
                    <Col md={4}>
                      <Form.Group className="mb-2">
                        <Form.Label>Religion</Form.Label>
                        <Form.Select name="religionId" value={formData.religionId} onChange={handleChange} required>
                          <option value="">Select Religion</option>
                          {religionOptions.map((r) => (
                            <option key={r.id} value={r.id}>
                              {r.name}
                            </option>
                          ))}
                        </Form.Select>
                      </Form.Group>
                    </Col>
                  </Row>

                  <Row className="mt-1">
                    <Col md={12}>
                      <Form.Group className="mb-2">
                        <Form.Label>Address</Form.Label>
                        <Form.Control type="text" placeholder="Enter address" name="address" value={formData.address} onChange={handleChange} />
                      </Form.Group>
                    </Col>
                  </Row>

                  <div className="section-title mt-2">Account</div>
                  <Row>
                    <Col md={4}>
                      <Form.Group className="mb-2">
                        <Form.Label>Username</Form.Label>
                        <Form.Control type="text" placeholder="Enter UserName" name="Username" value={formData.Username} onChange={handleChange} />
                      </Form.Group>
                    </Col>
                    <Col md={4}>
                      <Form.Group className="mb-2">
                        <Form.Label>Password</Form.Label>
                        <Form.Control type="password" placeholder="Enter password" name="password" value={formData.password} onChange={handleChange} required />
                      </Form.Group>
                    </Col>
                    <Col md={4}>
                      <Form.Group className="mb-2">
                        <Form.Label>Confirm Password</Form.Label>
                        <Form.Control type="password" placeholder="Confirm password" name="confirmPassword" value={formData.confirmPassword} onChange={handleChange} required />
                      </Form.Group>
                    </Col>
                  </Row>

                  <div className="d-grid">
                    <Button variant="primary" size="lg" type="submit">
                      Create account
                    </Button>
                  </div>
                </Form>
              </div>

              <br />
            </Card>
          </Col>
        </Row>
      </Container>
    </div>
  );
}

export default Register;
