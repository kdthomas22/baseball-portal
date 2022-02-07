import {
  Card,
  CardContent,
  Container,
  createStyles,
  FormControl,
  Grid,
  InputLabel,
  makeStyles,
  MenuItem,
  Select,
  Theme,
  Typography,
} from "@material-ui/core";
import { format } from "date-fns";
import { useEffect, useState } from "react";
import { useParams } from "react-router";
import PlayersApi from "../../api/PlayersApi";
import { PlayerData } from "../../models/PlayerData";
import { getPosition } from "../../utils/getPosition";
import Stats from "./Stats";

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    formControl: {
      margin: theme.spacing(1),
      minWidth: 120,
    },
    header: {
      textAlign: "center",
    },
    dataGrid: {
      alignContent: "center",
    },
    image: {
      marginLeft: 10,
    },
  })
);

const Player = () => {
  const classes = useStyles();
  const [loading, setLoading] = useState(true);
  const [player, setPlayer] = useState<PlayerData>();
  const [selectedYear, setSelectedYear] = useState(2019);
  const { playerId } = useParams<{ playerId: string }>();

  const getPlayerDetails = (playerId: number) => {
    setLoading(true);
    PlayersApi.getPlayerDetails(playerId)
      .then((res) => setPlayer(res))
      .catch((err) => console.log(err))
      .finally(() => setLoading(false));
  };

  useEffect(() => {
    getPlayerDetails(parseInt(playerId));
  }, [playerId]);

  return (
    <Container>
      <>
        {player && (
          <>
            <Card variant="outlined">
              <CardContent>
                <img src={player.headshoturl} />
                <Typography className={classes.header} variant="h3">
                  {`${player.firstname} ${player.lastname}`}
                </Typography>
              </CardContent>
              <Grid container>
                <Grid item md={4} xs={12}>
                  <Typography variant="h4">Bio</Typography>
                  <Typography>Birth City: {player.birthcity}</Typography>
                  {player.birthstate && (
                    <Typography>Birth State: {player.birthstate}</Typography>
                  )}
                  <Typography>Birth Country: {player.birthcountry}</Typography>
                  <Typography>
                    Birth Date: {format(new Date(player.birthdate!), "P")}
                  </Typography>
                  <Typography>
                    Position: {getPosition(player.position)}
                  </Typography>
                </Grid>
                <Grid item md={4} xs={12}>
                  <Typography variant="h4">Stats</Typography>

                  <Stats
                    playerId={parseInt(playerId)}
                    year={selectedYear}
                    player={player}
                  />
                </Grid>
                <Grid item md={4} xs={12}>
                  <FormControl className={classes.formControl}>
                    <InputLabel id="year-label">Select Year</InputLabel>
                    <Select
                      labelId="year-label"
                      value={selectedYear}
                      onChange={(e) =>
                        setSelectedYear(e.target.value as number)
                      }
                    >
                      <MenuItem value={2019}>2019</MenuItem>
                      <MenuItem value={2020}>2020</MenuItem>
                      <MenuItem value={2021}>2021</MenuItem>
                    </Select>
                  </FormControl>
                </Grid>
              </Grid>
            </Card>
          </>
        )}
      </>
    </Container>
  );
};

export default Player;
