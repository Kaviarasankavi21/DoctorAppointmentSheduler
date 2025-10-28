import React, { useState } from "react";
import { Card, Button, Form, Table, Container, Row, Col, Badge, Alert } from "react-bootstrap";
import { useAppointments } from "./Appointmentcontext";
import "../pages/Home.css";

function PatientAppointments() {
  const { appointments, setAppointments } = useAppointments();
  const [formData, setFormData] = useState({
    doctorId: "",
    date: "",
    time: "",
    reason: ""
  });
  const [showSuccess, setShowSuccess] = useState(false);

  const doctors = [
    { id: "1", name: "Dr. Kaviarasan K", specialization: "Cardiologist", experience: "15 years", fee: "₹800", availability: "Mon-Fri 9AM-5PM" },
    { id: "2", name: "Dr. Priya S", specialization: "Dermatologist", experience: "12 years", fee: "₹600", availability: "Mon-Sat 10AM-6PM" },
    { id: "3", name: "Dr. Arjun M", specialization: "Orthopedic", experience: "18 years", fee: "₹1000", availability: "Mon-Fri 8AM-4PM" },
    { id: "4", name: "Dr. Sarah Johnson", specialization: "Pediatrician", experience: "10 years", fee: "₹500", availability: "Mon-Sat 9AM-7PM" },
  ];

  const timeSlots = [
    "09:00", "09:30", "10:00", "10:30", "11:00", "11:30",
    "12:00", "12:30", "14:00", "14:30", "15:00", "15:30",
    "16:00", "16:30", "17:00", "17:30"
  ];

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    const newAppointment = {
      id: Date.now().toString(),
      doctor: doctors.find(d => d.id === formData.doctorId)?.name || "Unknown",
      specialization: doctors.find(d => d.id === formData.doctorId)?.specialization || "Unknown",
      date: formData.date,
      time: formData.time,
      reason: formData.reason,
      status: "Pending Confirmation"
    };

    setAppointments([...appointments, newAppointment]);
    setFormData({
      doctorId: "",
      date: "",
      time: "",
      reason: ""
    });
    setShowSuccess(true);
    setTimeout(() => setShowSuccess(false), 5000);
  };

  const handleCancel = (id) => {
    setAppointments(
      appointments.map((a) =>
        a.id === id ? { ...a, status: "Cancelled by Patient" } : a
      )
    );
  };

  const getStatusBadge = (status) => {
    const statusColors = {
      "Pending Confirmation": "warning",
      "Confirmed": "success",
      "Cancelled by Patient": "danger",
      "Cancelled by Doctor": "secondary",
      "Completed": "primary"
    };
    return <Badge bg={statusColors[status] || "secondary"}>{status}</Badge>;
  };

  return (
    <div className="appointment-page" style={{ minHeight: "100vh", background: "var(--bg)" }}>
      <Container className="py-4">

        <Row className="mb-4">
          <Col>
            <div className="text-center mb-4">
              <h1 className="display-6 fw-bold text-white mb-2">Book Your Appointment</h1>
              <p className="lead ">Schedule your medical consultation with our expert doctors</p>
            </div>
          </Col>
        </Row>

        {showSuccess && (
          <Row className="mb-4">
            <Col>
              <Alert variant="success" dismissible onClose={() => setShowSuccess(false)}>
                <Alert.Heading>Appointment Request Submitted!</Alert.Heading>
                Your appointment request has been sent successfully. You will receive a confirmation call within 24 hours.
              </Alert>
            </Col>
          </Row>
        )}

        <Row>
          <Col lg={9}>
            <Card className="appointment-card elevated-card mb-4">
              <Card.Header className="appointment-header">
                <h3 className="m-0">Schedule New Appointment</h3>
                <p className="mb-0">Fill in the details to book your appointment</p>
              </Card.Header>
              <Card.Body className="p-4">
                <Form onSubmit={handleSubmit}>
                  
                  {/* Preferred Date */}
                  <Form.Group className="mb-3">
                    <Form.Label className="fw-semibold">Preferred Date *</Form.Label>
                    <Form.Control
                      type="date"
                      name="date"
                      value={formData.date}
                      onChange={handleChange}
                      min={new Date().toISOString().split('T')[0]}
                      required
                    />
                  </Form.Group>

                  {/* Preferred Time */}
                  <Form.Group className="mb-3">
                    <Form.Label className="fw-semibold">Preferred Time *</Form.Label>
                    <Form.Select
                      name="time"
                      value={formData.time}
                      onChange={handleChange}
                      required
                    >
                      <option value="">Select time slot...</option>
                      {timeSlots.map((time) => (
                        <option key={time} value={time}>{time}</option>
                      ))}
                    </Form.Select>
                  </Form.Group>

                  {/* Doctor List */}
                  <Form.Group className="mb-3">
                    <Form.Label className="fw-semibold">Select Doctor *</Form.Label>
                    <Form.Select
                      name="doctorId"
                      value={formData.doctorId}
                      onChange={handleChange}
                      required
                    >
                      <option value="">Choose a doctor...</option>
                      {doctors.map((doctor) => (
                        <option key={doctor.id} value={doctor.id}>
                          {doctor.name} - {doctor.specialization}
                        </option>
                      ))}
                    </Form.Select>
                  </Form.Group>

                  {/* Reason */}
                  <Form.Group className="mb-4">
                    <Form.Label className="fw-semibold">Reason for Visit *</Form.Label>
                    <Form.Control
                      as="textarea"
                      rows={3}
                      name="reason"
                      value={formData.reason}
                      onChange={handleChange}
                      placeholder="Please describe your symptoms or reason for consultation..."
                      required
                    />
                  </Form.Group>

                  <div className="d-grid">
                    <Button variant="primary" size="lg" type="submit" className="book-btn">
                      <i className="fas fa-calendar-check me-2"></i>
                      Book Appointment
                    </Button>
                  </div>
                </Form>
              </Card.Body>
            </Card>
          </Col>

          {/* Doctors List */}
          <Col lg={3}>
            <Card className="elevated-card mb-4">
              <Card.Header className="appointment-header">
                <h5 className="m-0">Available Doctors</h5>
              </Card.Header>
              <Card.Body className="p-3">
                {doctors.map((doctor) => (
                  <div key={doctor.id} className="doctor-info mb-3 p-3 rounded" style={{ background: "var(--surface)" }}>
                    <h6 className="fw-bold mb-1">{doctor.name}</h6>
                    <p className="text-primary mb-2">{doctor.specialization}</p>
                    <div className="doctor-details">
                      <small className="d-block">Experience: {doctor.experience}</small>
                      <small className="d-block">Fee: {doctor.fee}</small>
                      <small className="d-block">Available: {doctor.availability}</small>
                    </div>
                  </div>
                ))}
              </Card.Body>
            </Card>
          </Col>
        </Row>

        {/* Appointments List */}
        <Row>
          <Col>
            <Card className="elevated-card">
              <Card.Header className="appointment-header">
                <h3 className="m-0">My Appointments</h3>
                <p className="text-muted mb-0">Track and manage your scheduled appointments</p>
              </Card.Header>
              <Card.Body className="p-0">
                {appointments.length === 0 ? (
                  <div className="text-center py-5">
                    <i className="fas fa-calendar-times fa-3x text-muted mb-3"></i>
                    <h5 className="text-muted">No appointments scheduled</h5>
                    <p className="text-muted">Book your first appointment using the form above</p>
                  </div>
                ) : (
                  <div className="table-responsive">
                    <Table hover className="mb-0">
                      <thead style={{ background: "var(--surface)" }}>
                        <tr>
                          <th className="border-0">Appointment ID</th>
                          <th className="border-0">Doctor</th>
                          <th className="border-0">Specialization</th>
                          <th className="border-0">Date</th>
                          <th className="border-0">Time</th>
                          <th className="border-0">Reason</th>
                          <th className="border-0">Status</th>
                          <th className="border-0">Actions</th>
                        </tr>
                      </thead>
                      <tbody>
                        {appointments.map((appointment) => (
                          <tr key={appointment.id}>
                            <td className="fw-semibold">#{appointment.id.toString().slice(-6)}</td>
                            <td>{appointment.doctor}</td>
                            <td>{appointment.specialization}</td>
                            <td>{new Date(appointment.date).toLocaleDateString()}</td>
                            <td>{appointment.time}</td>
                            <td className="text-truncate" style={{ maxWidth: "200px" }} title={appointment.reason}>
                              {appointment.reason}
                            </td>
                            <td>{getStatusBadge(appointment.status)}</td>
                            <td>
                              {appointment.status.includes("Confirmed") && (
                                <Button
                                  size="sm"
                                  variant="outline-danger"
                                  onClick={() => handleCancel(appointment.id)}
                                  className="cancel-btn"
                                >
                                  <i className="fas fa-times me-1"></i>
                                  Cancel
                                </Button>
                              )}
                              {appointment.status === "Pending Confirmation" && (
                                <small className="text-muted">Awaiting confirmation</small>
                              )}
                            </td>
                          </tr>
                        ))}
                      </tbody>
                    </Table>
                  </div>
                )}
              </Card.Body>
            </Card>
          </Col>
        </Row>
      </Container>
    </div>
  );
}

export default PatientAppointments;
