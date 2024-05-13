import React, { useState } from "react";
import "../styling/loginpage.css";
import "../styling/form.css";
import { useNavigate, Form, redirect } from "react-router-dom";
import axios from "axios";
import { SERVER_BASE_URL } from "../consts";

export default function SignUpForm() {
  const navigate = useNavigate();
  const [data, setData] = useState({
    username: "",
    name: "",
    fullName: "",
    password: "",
    cnp: "",
    phoneNumber: "",
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
        action="/patient-login/signup"
        className="form-container"
      >
        <h1>Sign Up</h1>
        <div className="input-container">
          <label htmlFor="name"></label>
          <input
            placeholder="Name"
            type="text"
            className="short-input"
            id="name"
            defaultValue={data["name"]}
            name="name"
            onChange={(e) => handleData(e, "name")}
          />
        </div>
        <div className="input-container">
          <label htmlFor="full-name"></label>
          <input
            placeholder="Full Name"
            type="text"
            className="short-input"
            id="full-name"
            defaultValue={data["fullName"]}
            name="fullName"
            onChange={(e) => handleData(e, "fullName")}
          />
        </div>
        <div className="input-container">
          <label htmlFor="phone-number"></label>
          <input
            placeholder="Phone Number"
            type="text"
            className="short-input"
            id="phone-number"
            defaultValue={data["phoneNumber"]}
            name="phoneNumber"
            onChange={(e) => handleData(e, "phoneNumber")}
          />
        </div>
        <div className="input-container">
          <label htmlFor="cnp"></label>
          <input
            placeholder="CNP"
            type="text"
            className="short-input"
            id="cnp"
            defaultValue={data["cnp"]}
            name="cnp"
            onChange={(e) => handleData(e, "cnp")}
          />
        </div>
        <div className="input-container">
          <label htmlFor="email"></label>
          <input
            placeholder="Email"
            type="text"
            className="short-input"
            id="email"
            defaultValue={data["username"]}
            name="userName"
            onChange={(e) => handleData(e, "username")}
          />
        </div>
        <div className="input-container">
          <label htmlFor="password"></label>
          <input
            placeholder="Password"
            type="password"
            className="short-input"
            id="password"
            defaultValue={data["password"]}
            name="password"
            onChange={(e) => handleData(e, "password")}
          />
        </div>
        <button className="submit-btn">Sign Up</button>
        <h4>Or if you already have an account: </h4>
      </Form>
      <button className="submit-btn" onClick={() => navigate("../login")}>
        Log In
      </button>
    </>
  );
}

export async function action({ request }) {
  const formData = await request.formData();

  const data = {
    name: formData.get("name"),
    fullName: formData.get("fullName"),
    phoneNumber: formData.get("phoneNumber"),
    cnp: formData.get("cnp"),
    userName: formData.get("userName"),
    password: formData.get("password"),
    role: "patient",
  };

  await axios({
    url: `${SERVER_BASE_URL}/api/UsersAuth/register`,
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    data,
  });

  return redirect("../login");
}
