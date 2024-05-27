import React, { useEffect, useState } from "react";
import "../styling/loginpage.css";
import "../styling/form.css";
import { Form, json, redirect, useActionData } from "react-router-dom";
import { useNavigate } from "react-router-dom";
import { SERVER_BASE_URL } from "../consts";
import axios from "axios";
import toast, { Toaster } from "react-hot-toast";

function LoginFormAdmin() {
  const navigate = useNavigate();
  const error = useActionData();

  const [data, setData] = useState({
    username: "",
    password: "",
  });

  const handleData = (e, identifier) => {
    setData((prevData) => {
      let newData = prevData;
      newData[identifier] = e.target.value;
      return newData;
    });
  };

  useEffect(() => {
    if (error) {
      toast.error(error.error, {
        duration: 2000,
      });
    }
  }, [error]);

  return (
    <>
      <div>
        <Toaster />
      </div>
      <Form method="POST" action="/admin-login/login">
        <h1> Log in </h1>
        <div className="input-container">
          <label htmlFor="username"></label>
          <input
            placeholder="Username"
            type="text"
            id="username"
            className="short-input"
            defaultValue={data["username"]}
            name="username"
            onChange={(e) => handleData(e, "username")}
          />
        </div>
        <div className="input-container">
          <label htmlFor="password"></label>
          <input
            placeholder="Password"
            type="password"
            id="password"
            className="short-input"
            defaultValue={data["password"]}
            name="password"
            onChange={(e) => handleData(e, "password")}
          />
        </div>
        <button className="submit-btn">Login</button>
      </Form>
    </>
  );
}

export default LoginFormAdmin;

export async function action({ request }) {
  const formData = await request.formData();

  const data = {
    userName: formData.get("username"),
    password: formData.get("password"),
  };

  try {
    const response = await axios.post(
      `${SERVER_BASE_URL}/api/UsersAuth/login`,
      data,
      {
        headers: {
          "Content-Type": "application/json",
        },
      }
    );

    if (response.status === 200) {
      localStorage.setItem("token", response.data.result.token);
      return redirect("/patient-account");
    }
  } catch (err) {
    return json({
      error:
        err.response.data.errorMessages[0] ||
        "Failed to login, please try again later",
    });
  }
}
