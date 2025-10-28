
import React from "react";
import { Card, Button, Row, Col } from "react-bootstrap";
import { Link } from "react-router-dom";

function DoctorList() {
  const doctors = [
    {
      id: 1,
      name: "Dr. Kaviarasan K",
      specialization: "Cardiologist",
      details: "MBBS, MD (Cardiology) with 10+ years of experience.",
    },
    {
      id: 2,
      name: "Dr. Priya S",
      specialization: "Dermatologist",
      details: "Expert in skin treatments with 7 years of clinical practice.",
    },
    {
      id: 3,
      name: "Dr. Arjun M",
      specialization: "Orthopedic",
      details: "Specialist in bone & joint care with 12+ years of experience.",
    },
    {
      id: 4,
      name: "Dr. Selva M",
      specialization: "Nephrology",
      details: "Specialist in kidney care with 12+ years of experience.",
    },
  ];

  return (
    <div className="container mt-4">
      <h2 className="mb-4">Available Doctors</h2>
      <Row>
        {doctors.map((doc) => (
          <Col md={4} key={doc.id} className="mb-4">
            <Card className="shadow p-3 h-100">
              <Card.Body>
                <Card.Title>{doc.name}</Card.Title>
                <Card.Subtitle className="mb-2 text-muted">
                  {doc.specialization}
                </Card.Subtitle>
                <Card.Text>{doc.details}</Card.Text>
                <Link to={`/doctor/${doc.id}`}>
                  <Button variant="primary">View Profile</Button>
                </Link>
              </Card.Body>
            </Card>
          </Col>
        ))}
      </Row>
    </div>
  );
}

export default DoctorList;
