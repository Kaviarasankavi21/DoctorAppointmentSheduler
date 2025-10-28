import { Link } from "react-router-dom";
import Card from "react-bootstrap/Card";
import CardGroup from "react-bootstrap/CardGroup";

function Home() {
  return (
    <>
      
      <section className="home-hero-v2">
        <div className="hero-bg" style={{ backgroundImage: "url('src/assets/IMG/operating-room-standards-2700x1350.jpg')" }} />
        <div className="container">
          <div className="hero-content">
            <div className="eyebrow">Your health, our priority</div>
            <h1>Doctor appointment scheduling made simple</h1>
            <p>Find trusted specialists and book visits in minutes. Manage all your appointments in one secure place.</p>
            <div className="hero-actions">
              <Link to="/doctors" className="btn btn-primary me-2">Find a doctor</Link>
              <Link to="/appointments" className="btn btn-outline-light">Book appointment</Link>
            </div>
          </div>
        </div>
      </section>

      
      <section className="benefits container my-5">
        <div className="row g-3">
          <div className="col-md-4">
            <div className="benefit-card elevated-card p-4 h-100">
              <div className="benefit-badge">Fast</div>
              <h3 className="mt-2">Book in minutes</h3>
              <p>Search, compare, and schedule without phone calls or waiting.</p>
            </div>
          </div>
          <div className="col-md-4">
            <div className="benefit-card elevated-card p-4 h-100">
              <div className="benefit-badge">Trusted</div>
              <h3 className="mt-2">Top specialists</h3>
              <p>Verified doctors across cardiology, orthopedics, nephrology, and more.</p>
            </div>
          </div>
          <div className="col-md-4">
            <div className="benefit-card elevated-card p-4 h-100">
              <div className="benefit-badge">Secure</div>
              <h3 className="mt-2">Private & safe</h3>
              <p>Your health data stays protected with secure storage.</p>
            </div>
          </div>
        </div>
      </section>

      
      <section className="container specialties-v2 my-5">
        <h2 className="section-heading text-center mb-3">Explore specialties</h2>
        <p className="text-center text-muted mb-4">Choose from popular departments and find the right doctor.</p>
        <CardGroup className="specialties-grid">
          <Card className="specialty-card elevated-card">
            <Card.Img className="specialty-image" variant="top" src="src/assets/IMG/doctor-05-1.webp" />
            <Card.Body>
              <Card.Title>Cardiology</Card.Title>
              <Card.Text>Heart and blood vessel care from leading cardiologists.</Card.Text>
            </Card.Body>
          </Card>
          <Card className="specialty-card elevated-card">
            <Card.Img className="specialty-image" variant="top" src="src/assets/IMG/doctor-thumb-07.webp" />
            <Card.Body>
              <Card.Title>Orthopedics</Card.Title>
              <Card.Text>Expert treatment for bones, joints, and muscles.</Card.Text>
            </Card.Body>
          </Card>
          <Card className="specialty-card elevated-card">
            <Card.Img className="specialty-image" variant="top" src="src/assets/IMG/doctor-thumb-08.webp" />
            <Card.Body>
              <Card.Title>Nephrology</Card.Title>
              <Card.Text>Advanced kidney care and renal health management.</Card.Text>
            </Card.Body>
          </Card>
        </CardGroup>
      </section>

      
      <section className="how-it-works container my-5">
        <h2 className="section-heading text-center mb-4">How it works</h2>
        <div className="row g-3">
          <div className="col-md-4">
            <div className="step-card elevated-card p-4 h-100">
              <div className="step-number">1</div>
              <h4 className="mt-2">Search doctors</h4>
              <p>Browse by specialty, location, and availability.</p>
            </div>
          </div>
          <div className="col-md-4">
            <div className="step-card elevated-card p-4 h-100">
              <div className="step-number">2</div>
              <h4 className="mt-2">Pick a time</h4>
              <p>Choose an appointment slot that suits your schedule.</p>
            </div>
          </div>
          <div className="col-md-4">
            <div className="step-card elevated-card p-4 h-100">
              <div className="step-number">3</div>
              <h4 className="mt-2">Confirm & manage</h4>
              <p>Get reminders and manage upcoming visits easily.</p>
            </div>
          </div>
        </div>
      </section>

      
      <section className="testimonials container my-5">
        <div className="row g-3">
          <div className="col-md-6">
            <div className="testimonial-card elevated-card p-4 h-100">
              <p className="quote">“Booking was so quick and easy. I found a great cardiologist and confirmed an appointment in under 2 minutes.”</p>
              <div className="author">— Priya K.</div>
            </div>
          </div>
          <div className="col-md-6">
            <div className="testimonial-card elevated-card p-4 h-100">
              <p className="quote">“Modern, clean design and I love the reminders. Managing my visits is effortless now.”</p>
              <div className="author">— Arjun M.</div>
            </div>
          </div>
        </div>
      </section>

      
      <section className="cta-band container my-5">
        <div className="cta-inner elevated-card p-4 d-flex flex-column flex-md-row align-items-center justify-content-between">
          <div>
            <h3 className="m-0">Ready to schedule your appointment?</h3>
            <div className="text-muted">Find a specialist and book in minutes.</div>
          </div>
          <div className="mt-3 mt-md-0">
            <Link to="/appointments" className="btn btn-primary me-2">Book now</Link>
            <Link to="/doctors" className="btn btn-outline-light">Browse doctors</Link>
          </div>
        </div>
      </section>
    </>
  );
}

export default Home;
