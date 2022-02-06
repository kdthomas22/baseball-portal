import { useEffect, useState } from "react";
import { useParams } from "react-router";
import PlayersApi from "../../api/PlayersApi";
import { PlayerData } from "../../models/PlayerData";
import Stats from "./Stats";

const Player = () => {
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
  }, []);

  return (
    <div>
      {player && (
        <>
          <p>{player.firstname}</p>
          <Stats playerId={parseInt(playerId)} year={selectedYear} />
        </>
      )}
    </div>
  );
};

export default Player;
