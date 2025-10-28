import React, { createContext, useState, useContext } from "react";

const AppointmentContext = createContext();

export function AppointmentProvider({ children }) {
  const [appointments, setAppointments] = useState([
    {
      id: 1,
      patient: "John Doe",
      doctor: "Dr. Kaviarasan K",
      specialization: "Cardiologist",
      date: "2025-09-20",
      time: "10:30 AM",
      reason: "Chest Pain",
      status: "Confirmed",
    },
    {
      id: 2,
      patient: "Mary Smith",
      doctor: "Dr. Priya S",
      specialization: "Dermatologist",
      date: "2025-09-25",
      time: "02:00 PM",
      reason: "Skin Allergy",
      status: "Confirmed",
    },
  ]);

  return (
    <AppointmentContext.Provider value={{ appointments, setAppointments }}>
      {children}
    </AppointmentContext.Provider>
  );
}

// custom hook
export const useAppointments = () => useContext(AppointmentContext);
