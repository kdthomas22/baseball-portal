import { useEffect, useState } from "react";
import { useHistory, useParams } from "react-router";
import TeamApi from "../../api/TeamApi";
import { TeamDetails } from "../../models/TeamDetails";

const Team = () => {
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

  useEffect(() => {
    getTeamDetails(parseInt(teamId));
  }, []);

  return (
    <div>
      <p>{team?.name}</p>
      {team?.players.map((p) => (
        <p onClick={() => history.push(`/player/${p.playerid}`)}>
          {p.usesname}
        </p>
      ))}
    </div>
  );
};

export default Team;
