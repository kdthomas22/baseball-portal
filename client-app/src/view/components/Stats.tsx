import { useEffect, useState } from "react";
import PlayersApi from "../../api/PlayersApi";
import { PlayerStats } from "../../models/PlayerStats";

interface Props {
  year: number;
  playerId: number;
}

const Stats = ({ year, playerId }: Props) => {
  const [loading, setLoading] = useState(false);
  const [stats, setStats] = useState<PlayerStats>();

  const getStats = (playerId: number, year: number) => {
    setLoading(true);
    PlayersApi.getPlayerStats(playerId, year)
      .then((res) => setStats(res))
      .catch((err) => console.log(err))
      .finally(() => setLoading(false));
  };

  useEffect(() => {
    getStats(playerId, year);
  }, [year]);

  return <div>{stats && stats.isPitcher && <p>{stats.era}</p>}</div>;
};

export default Stats;
