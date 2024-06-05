import React from "react";
import "../styling/loginpage.css";
import { useNavigate } from "react-router-dom";
import { Outlet } from "react-router-dom";

function AdminAccountPage() {
  const navigate = useNavigate();

  const toggleLoadPage = (page) => {
    navigate(page);
  };

  return (
    <>
      <div className="login-container">
        <img src="../assets/anca.png" alt="Login Image" />
        <div className="purple-overlay">
          <>
            <button
              className="buttonLog"
              onClick={() => toggleLoadPage("admin-see-appointments")}
            >
              Appointmetns
            </button>
            <button
              className="buttonSign"
              onClick={() => toggleLoadPage("admin-see-procedures")}
            >
              Procedures
            </button>
            <button
              className="buttonSign"
              onClick={() => toggleLoadPage("admin-see-sections")}
            >
              Sections
            </button>
            <button
              className="buttonSign"
              onClick={() => toggleLoadPage("admin-see-users")}
            >
              Users
            </button>
          </>
        </div>
      </div>
      <Outlet />
    </>
  );
}

export default AdminAccountPage;