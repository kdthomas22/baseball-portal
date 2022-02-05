import { Route, Switch } from "react-router";
import Home from "../view/components/Home";
import Player from "../view/components/Player";
import Team from "../view/components/Team";

const AppRouter = () => {
  return (
    <Switch>
      <Route exact path="/" component={Home} />
      <Route path="/team/:teamId" component={Team} />
      <Route path="/player/:playerId" component={Player} />
    </Switch>
  );
};

export default AppRouter;
