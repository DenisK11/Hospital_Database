import React, { useState } from "react";
import "../styling/loginpage.css";
import "../styling/form.css";
import { useNavigate, Form, redirect } from "react-router-dom";
import axios from "axios";
import { SERVER_BASE_URL } from "../consts";

export default function AdminMakeAppointmentForm() {
  const navigate = useNavigate();
  const [data, setData] = useState({
    section: "",
    procedure: "",
    date: "",
    
  });

  const handleData = (e, identifier) => {
    setData((prevData) => {
      let newData = prevData;
      newData[identifier] = e.target.value;
      return newData;
    });
  };

  return (
    <>
      <Form
        method="POST"
        action="/admin-account/admin-see-appointments/admin-make-appointment"
        className="form-container"
      >
        <h1>Make Appointment</h1>
        <div className="input-container">
          <label htmlFor="section"></label>
          <input
            placeholder="Section"
            type="text"
            className="short-input"
            id="section"
            defaultValue={data["section"]}
            name="section"
            onChange={(e) => handleData(e, "section")}
          />
        </div>
        <div className="input-container">
          <label htmlFor="procedure"></label>
          <input
            placeholder="Procedure"
            type="text"
            className="short-input"
            id="procedure"
            defaultValue={data["procedure"]}
            name="fullName"
            onChange={(e) => handleData(e, "pr")}
          />
        </div>
        <div className="input-container">
          <label htmlFor="date"></label>
          <input
            placeholder="Date"
            type="text"
            className="short-input"
            id="date"
            defaultValue={data["date"]}
            name="date"
            onChange={(e) => handleData(e, "pr")}
          />
        </div>
        <button className="submit-btn">Make Appointment</button>
      </Form>
    </>
  );
}

export async function action({ request }) {
  const formData = await request.formData();

  const data = {
    section: formData.get("section"),
    procedure: formData.get("procedure"),
    date: formData.get("date")
  };

  await axios({
    url: `${SERVER_BASE_URL}/api/AppointmentAPI`,
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    data,
  });

  return redirect("../patient-account");
}