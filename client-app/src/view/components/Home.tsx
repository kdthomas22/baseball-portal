import {
  CircularProgress,
  Container,
  Divider,
  Grid,
  List,
  ListItem,
  ListItemText,
  ListSubheader,
  makeStyles,
  Paper,
} from "@material-ui/core";
import { useHistory } from "react-router";
import { useTeams } from "../../state/provider/TeamProvider";
import {} from "../../";

const useStyles = makeStyles({
  subheader: {
    fontSize: "50px",
    color: "#000000",
  },
  container: {
    marginTop: 30,
  },
  progress: {
    display: "flex",
    justifyContent: "center",
  },
});

const Home = () => {
  const { teams, loadingTeams } = useTeams();
  let history = useHistory();
  const classes = useStyles();

  const americanLeague = teams.filter((t) => t.leagueid === 1);
  const nationalLeague = teams.filter((t) => t.leagueid === 2);

  if (loadingTeams) return <CircularProgress className={classes.progress} />;

  return (
    <Container className={classes.container}>
      <Grid container spacing={3}>
        <Grid item xs={12} sm={6} md={6} spacing={3}>
          <Paper variant="outlined">
            <List>
              <ListSubheader className={classes.subheader}>
                American League
              </ListSubheader>
              {americanLeague.map((t) => (
                <>
                  <ListItem
                    button
                    onClick={() => history.push(`/team/${t.teamid}`)}
                  >
                    <ListItemText primary={`${t.city} ${t.name}`} />
                  </ListItem>
                  <Divider />
                </>
              ))}
            </List>
          </Paper>
        </Grid>
        <Grid item xs={12} sm={6} md={6} spacing={3}>
          <Paper variant="outlined">
            <List>
              <ListSubheader className={classes.subheader}>
                National League
              </ListSubheader>
              {nationalLeague.map((t) => (
                <>
                  <ListItem
                    button
                    onClick={() => history.push(`/team/${t.teamid}`)}
                  >
                    <ListItemText primary={`${t.city} ${t.name}`} />
                  </ListItem>
                  <Divider />
                </>
              ))}
            </List>
          </Paper>
        </Grid>
      </Grid>
    </Container>
  );
};

export default Home;
