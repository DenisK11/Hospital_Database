import React from "react";
import "../styling/loginpage.css";
import { useNavigate } from "react-router-dom";
import { Outlet } from "react-router-dom";

function AdminSeeProcedures() {
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
              onClick={() => toggleLoadPage("get-all-procedures")}
            >
              Get All Procedures
            </button>
            <button
              className="buttonSign"
              onClick={() => toggleLoadPage("delete-procedure")}
            >
               Delete Procedure
            </button>
            <button
              className="buttonSign"
              onClick={() => toggleLoadPage("post-procedure")}
            >
              Post Procedure
            </button>
          </>
        </div>
      </div>
      <Outlet />
    </>
  );
}

export default AdminSeeProcedures;