import React, { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import './Home.css'
import { Button } from "react-bootstrap";
import axios from 'axios';

function LoginPage() {
  
  
  const [formData, setFormData] = useState({ username: "", hashedpassword: "" }); 
  const [error, setError] = useState(null); 
  const navigate = useNavigate(); 
  
  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError(null); 

    try {
      
      
 const response = await axios.post('http://localhost:5185/api/Auth/login', formData);

      console.log("Login successful:", response.data);

      const token = response.data.token;
      localStorage.setItem('userToken', token); 
      navigate("/home");

    } catch (err) {
      if (err.response) {
        console.error("Login failed:", err.response.data);
        setError(err.response.data.message || "Login failed. Please check your credentials.");
      } else if (err.request) {
        console.error("No response from server:", err.request);
        setError("Could not connect to the server. Please try again later.");
      } else {
        console.error("Error", err.message);
        setError("An unexpected error occurred.");
      }
    }
  };

  let handleregister = () => {
    navigate("/Register");
  }

  return (
    <div className="logindiv d-flex">
      <div className="container p-3 my-4 w-100">
        <div className="formdiv">
          <div className="login-card elevated-card">
            <div className="login-visual d-none d-lg-block" />
            <div className="login-content">
              <div className="mb-3 brand-title">Doctor Appointment Scheduler</div>
              <div className="headline">Welcome back</div>
              <div className="subheadline">Sign in to manage your appointments</div>
              {error && <div className="alert alert-danger">{error}</div>}
              <form onSubmit={handleSubmit}>
                <div className="mb-3">
                  <label className="form-label">Username</label>
                  <input
                    type="text"
                    name="username"
                    className="form-control"
                    placeholder="Enter your username"
                    onChange={handleChange}
                    autoComplete="username"
                    required
                  />
                </div>
                <div className="mb-2">
                  <label className="form-label">Password</label>
                  <input
                    type="password"
                    name="hashedpassword"
                    className="form-control"
                    placeholder="Enter your password"
                    onChange={handleChange}
                    autoComplete="current-password"
                    required
                  />
                </div>
                <br />
                <Button type="submit" className="btn btn-primary w-100">
                  Login
                </Button>
              </form>
              <div className="small fw-bold mt-3">
                Don't have an account?{' '}
                <Button variant="outline-primary" className="w-100 mt-2" onClick={handleregister}>New patient / Register</Button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
 

export default LoginPage;