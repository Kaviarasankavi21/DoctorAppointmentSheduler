import React, { useState } from "react";
import { Card, Button, Table } from "react-bootstrap";

function DoctorAppointments() {
  const { appointments, setAppointments } = useAppointments();
  const [selectedDate, setSelectedDate] = useState(new Date());

  const formatDate = (date) => date.toISOString().split("T")[0];
  const today = formatDate(new Date());

  const handleCancel = (id) => {
    setAppointments(
      appointments.map((a) =>
        a.id === id ? { ...a, status: "Cancelled by Doctor" } : a
      )
    );
  };

  const todaysAppointments = appointments.filter((a) => a.date === today);
  const selectedAppointments = appointments.filter(
    (a) => a.date === formatDate(selectedDate)
  );

  return (
    <div className="container mt-4">
      <h2>Doctor Dashboard - Appointments</h2>

      <Card className="p-3 mb-4 shadow">
        <h4>Today's Scheduled Appointments ({today})</h4>
        <Table striped bordered hover>
          <thead>
            <tr>
              <th>ID</th>
              <th>Patient</th>
              <th>Time</th>
              <th>Reason</th>
              <th>Status</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {todaysAppointments.map((a) => (
              <tr key={a.id}>
                <td>{a.id}</td>
                <td>{a.patient}</td>
                <td>{a.time}</td>
                <td>{a.reason}</td>
                <td>{a.status}</td>
                <td>
                  {a.status.includes("Confirmed") && (
                    <Button
                      size="sm"
                      variant="danger"
                      onClick={() => handleCancel(a.id)}
                    >
                      Cancel
                    </Button>
                  )}
                </td>
              </tr>
            ))}
          </tbody>
        </Table>
      </Card>

      <Card className="p-3 shadow">
        <h4>Calendar View</h4>
        <div className="d-flex gap-4">
          <Calendar onChange={setSelectedDate} value={selectedDate} />
          <div style={{ flex: 1 }}>
            <h5>Appointments on {formatDate(selectedDate)}</h5>
            <Table striped bordered hover>
              <thead>
                <tr>
                  <th>ID</th>
                  <th>Patient</th>
                  <th>Time</th>
                  <th>Reason</th>
                  <th>Status</th>
                  <th>Actions</th>
                </tr>
              </thead>
              <tbody>
                {selectedAppointments.map((a) => (
                  <tr key={a.id}>
                    <td>{a.id}</td>
                    <td>{a.patient}</td>
                    <td>{a.time}</td>
                    <td>{a.reason}</td>
                    <td>{a.status}</td>
                    <td>
                      {a.status.includes("Confirmed") && (
                        <Button
                          size="sm"
                          variant="danger"
                          onClick={() => handleCancel(a.id)}
                        >
                          Cancel
                        </Button>
                      )}
                    </td>
                  </tr>
                ))}
              </tbody>
            </Table>
          </div>
        </div>
      </Card>
    </div>
  );
}

export default DoctorAppointments;
