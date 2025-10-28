import React from "react";
import { useParams, Link } from "react-router-dom";
import { Card, Button } from "react-bootstrap";

function DoctorPage() {
  const { id } = useParams();
  const doctors = [
    {
      id: 1,
      name: "Dr. Kaviarasan K",
      specialization: "Cardiologist",
      details:
        "MBBS, MD (Cardiology) with 10+ years of experience in treating heart-related diseases.",
      availability: "Mon - Fri, 10:00 AM - 4:00 PM",
      location: "Apollo Hospitals, Chennai",
    },
    {
      id: 2,
      name: "Dr. Priya S",
      specialization: "Dermatologist",
      details:
        "Expert in skin treatments with 7 years of clinical practice.",
      availability: "Tue - Sat, 11:00 AM - 5:00 PM",
      location: "Fortis Hospital, Chennai",
    },
    {
      id: 3,
      name: "Dr. Arjun M",
      specialization: "Orthopedic",
      details:
        "Specialist in bone & joint care with 12+ years of experience.",
      availability: "Mon - Sat, 9:00 AM - 3:00 PM",
      location: "MIOT Hospitals, Chennai",
    },
    {
      id: 4,
      name: "Dr. selva M",
      specialization: "Orthopedic",
      details:
        "Specialist in bone & joint care with 12+ years of experience.",
      availability: "Mon - Sat, 9:00 AM - 3:00 PM",
      location: "MIOT Hospitals, Chennai",
    },
  ];

  const doctor = doctors.find((d) => d.id === parseInt(id));

  if (!doctor) {
    return <h2 className="text-center mt-5">Doctor not found</h2>;
  }

  return (
    <div className="container mt-4">
      <Card className="shadow p-4">
        <h2>{doctor.name}</h2>
        <h5 className="text-muted">{doctor.specialization}</h5>
        <p>{doctor.details}</p>
        <p><strong>Availability:</strong> {doctor.availability}</p>
        <p><strong>Location:</strong> {doctor.location}</p>
        <Link to="/doctors">
          <Button variant="secondary">Back to List</Button>
        </Link>
      </Card>
    </div>
  );
}

export default DoctorPage;
