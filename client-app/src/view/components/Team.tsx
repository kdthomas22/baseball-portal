import { useEffect, useState } from "react";
import { useHistory, useParams } from "react-router";
import TeamApi from "../../api/TeamApi";
import { TeamDetails } from "../../models/TeamDetails";
import {
  Avatar,
  Button,
  Container,
  makeStyles,
  Typography,
} from "@material-ui/core";
import MaterialTable from "material-table";
import { PlayerData } from "../../models/PlayerData";
import { getPosition } from "../../utils/getPosition";

const useStyles = makeStyles({
  header: {
    textAlign: "center",
  },
  table: {
    marginTop: 20,
  },
  image: {
    height: "auto",
    width: "50px",
  },
});

const Team = () => {
  const classes = useStyles();
  const [loading, setLoading] = useState(false);
  const [team, setTeam] = useState<TeamDetails>();
  const { teamId } = useParams<{ teamId: string }>();

  const history = useHistory();

  const getTeamDetails = (teamId: number) => {
    setLoading(true);
    TeamApi.getTeamDetails(teamId)
      .then((res) => setTeam(res))
      .catch((err) => console.log(err))
      .finally(() => setLoading(false));
  };

  const columns: any = [
    {
      field: "headshoturl",
      render: (rowData: PlayerData) => <Avatar src={rowData.headshoturl} />,
    },
    {
      title: "First Name",
      field: "firstname",
      render: (rowData: PlayerData) => (
        <Typography>{rowData.firstname}</Typography>
      ),
    },
    {
      title: "Last Name",
      field: "lastname",
      render: (rowData: PlayerData) => (
        <Typography>{rowData.lastname}</Typography>
      ),
    },
    {
      title: "Bats",
      field: "bats",
      render: (rowData: PlayerData) =>
        rowData.bats === 1 ? (
          <Typography>R</Typography>
        ) : rowData.bats === 2 ? (
          <Typography>L</Typography>
        ) : (
          <Typography>R/L</Typography>
        ),
    },
    {
      title: "Throws",
      field: "throws",
      render: (rowData: PlayerData) =>
        rowData.throws === 1 ? (
          <Typography>R</Typography>
        ) : (
          <Typography>L</Typography>
        ),
    },
    {
      title: "Height",
      field: "height",
      render: (rowData: PlayerData) => (
        <Typography>{rowData.height} in.</Typography>
      ),
    },
    {
      title: "Weight",
      field: "weight",
      render: (rowData: PlayerData) => (
        <Typography>{rowData.weight} lbs.</Typography>
      ),
    },
    {
      title: "Position",
      field: "position",
      render: (rowData: PlayerData) => (
        <Typography>{getPosition(rowData.position)}</Typography>
      ),
    },
    {
      title: "Number",
      field: "number",
      render: (rowData: PlayerData) => (
        <Typography>{rowData.number} </Typography>
      ),
    },
    {
      render: (rowData: PlayerData) => (
        <Button onClick={() => history.push(`/player/${rowData.playerid}`)}>
          Bio/Stats{" "}
        </Button>
      ),
    },
  ];

  useEffect(() => {
    getTeamDetails(parseInt(teamId));
  }, []);

  return (
    <Container>
      <Typography
        variant="h3"
        className={classes.header}
      >{`${team?.city} ${team?.name}`}</Typography>
      <div className={classes.table}>
        <MaterialTable
          title="Roster"
          columns={columns}
          data={team?.players ?? []}
        />
      </div>
    </Container>
  );
};

export default Team;
