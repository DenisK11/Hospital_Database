import React from "react";
import "../styling/loginpage.css";
import { useNavigate } from "react-router-dom";
import { Outlet } from "react-router-dom";

function AdminSeeAppointments() {
  const navigate = useNavigate();

  const toggleLoadPage = (page) => {
    navigate(page);
  };

  return (
    <>
      <div className="login-container">
        <div className="purple-overlay">
          <>
            <button
              className="buttonLog"
              onClick={() => toggleLoadPage("get-all-appointments")}
            >
              Get All Appointmetns
            </button>
            <button
              className="buttonSign"
              onClick={() => toggleLoadPage("delete-appointment")}
            >
               Delete Appointment
            </button>
            <button
              className="buttonSign"
              onClick={() => toggleLoadPage("admin-make-appointment")}
            >
              Make Appointment
            </button>
          </>
        </div>
      </div>
      <Outlet />
    </>
  );
}

export default AdminSeeAppointments;