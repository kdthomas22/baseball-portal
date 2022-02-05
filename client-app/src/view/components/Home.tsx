import {
  Card,
  CardContent,
  CircularProgress,
  Container,
  Grid,
  Typography,
} from "@mui/material";
import { useHistory } from "react-router";
import { useTeams } from "../../state/provider/TeamProvider";

const Home = () => {
  const { teams, loadingTeams } = useTeams();
  let history = useHistory();

  if (loadingTeams) return <CircularProgress />;

  return (
    <div>
      <Container>
        <Grid container>
          {teams.map((team) => (
            <Grid item md={3} spacing={3}>
              <Card onClick={() => history.push(`/team/${team.teamid}`)}>
                <CardContent>
                  <Typography>{team.name}</Typography>
                </CardContent>
              </Card>
            </Grid>
          ))}
        </Grid>
      </Container>
    </div>
  );
};

export default Home;
