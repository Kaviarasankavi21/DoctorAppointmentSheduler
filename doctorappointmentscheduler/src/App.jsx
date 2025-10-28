
import { BrowserRouter as Router, Routes, Route, useLocation } from "react-router-dom";
import DoctorList from "./Component/DoctorList";
import Navbar from "./Component/Navbar";
import Home from "./pages/Home";
import LoginPage from "./pages/Login";
import Register from "./Component/Register";
import DoctorPage from "./Component/Doctorpage";
import PatientAppointments from './Component/Patientappointment'
import DoctorAppointments from './Component/Doctorappointment'
import { AppointmentProvider } from "./Component/Appointmentcontext";

function AppWrapper() {
  const location = useLocation();
  const hideNavbar = location.pathname === "/" || location.pathname === "/Register";

  return (
    <>
      {!hideNavbar && <Navbar />}
      <div className="p-4">
        <Routes>
          <Route path="/home" element={<Home />} />
          <Route path="/doctors" element={<DoctorList />} />
          <Route path="/doctor/:id" element={<DoctorPage />} />
          <Route path="/appointments" element={<PatientAppointments />} />
          <Route path="/patient" element={<PatientAppointments />} />
          <Route path="/doctor" element={<DoctorAppointments />} />
          <Route path="/about" element={<h2></h2>} />
          <Route path="/" element={<LoginPage />} />
          <Route path="/register" element={<Register />} />
        </Routes>
      </div>
    </>
  );
}

function App() {
  return (
    <AppointmentProvider>
      <Router>
          <AppWrapper />
      </Router>
    </AppointmentProvider>
  );
}

export default App;
