import { Outlet } from "react-router-dom";
import Home from "./pages/Home"

export default function Root() {
  return (
    <>
      <Home />
      <Outlet />
    </>
  );
}
