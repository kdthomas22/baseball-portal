import ReactDOM from "react-dom";
import "./index.css";
import App from "./app/App";
import { TeamProvider } from "./state/provider/TeamProvider";

ReactDOM.render(
  <TeamProvider>
    <App />
  </TeamProvider>,

  document.getElementById("root")
);
