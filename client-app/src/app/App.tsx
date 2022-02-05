import { Router } from "react-router";
import Layout from "../layout";
import history from "../router/history";

function App() {
  return (
    <Router history={history}>
      <Layout />
    </Router>
  );
}

export default App;
