import { useEffect, useState } from "react";
import { useParams } from "react-router";
import PlayersApi from "../../api/PlayersApi";
import { PlayerData } from "../../models/PlayerData";

const Player = () => {
  const [loading, setLoading] = useState(true);
  const [player, setPlayer] = useState<PlayerData>();
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

  return <div>{player && <p>{player.firstname}</p>}</div>;
};

export default Player;
