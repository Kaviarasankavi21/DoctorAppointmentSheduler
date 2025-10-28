import { Link } from "react-router-dom";
import { Navbar, Nav, Container } from "react-bootstrap";
import "./Navbar.css";  

export default function AppNavbar() {
  return (
    <Navbar expand="lg" sticky="top">
      <Container>
        <Navbar.Brand as={Link} to="/">
          Doctor Appointment Scheduler
        </Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="ms-auto">
            <Nav.Link as={Link} to="/home">Home</Nav.Link>
            <Nav.Link as={Link} to="/doctors">Doctors</Nav.Link>
            <Nav.Link as={Link} to="/appointments">Appointments</Nav.Link>
            <Nav.Link as={Link} to="/about">About</Nav.Link>
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
}

