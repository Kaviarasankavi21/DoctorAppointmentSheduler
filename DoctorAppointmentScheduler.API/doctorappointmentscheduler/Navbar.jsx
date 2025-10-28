import { Link } from "react-router-dom";

export default function Navbar() {
  return (
    <nav className="bg-blue-600 text-white px-6 py-4 flex justify-between items-center shadow-md">
      {/* Project Name / Logo */}
      <h1 className="text-2xl font-bold">Doctor Appointment Scheduler</h1>

      {/* Navigation Links */}
      <ul className="flex gap-6">
        <li>
          <Link to="/" className="hover:text-yellow-300">Home</Link>
        </li>
        <li>
          <Link to="/doctors" className="hover:text-yellow-300">Doctors</Link>
        </li>
        <li>
          <Link to="/appointments" className="hover:text-yellow-300">Appointments</Link>
        </li>
        <li>
          <Link to="/about" className="hover:text-yellow-300">About</Link>
        </li>
        <li>
          <Link to="/login" className="hover:text-yellow-300">Login</Link>
        </li>
      </ul>
    </nav>
  );
}
