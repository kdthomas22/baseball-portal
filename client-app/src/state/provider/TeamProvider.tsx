import React, { useContext, useEffect, useState } from "react";
import PlayersApi from "../../api/PlayersApi";
import TeamApi from "../../api/TeamApi";
import { PlayerData } from "../../models/PlayerData";
import { TeamData } from "../../models/TeamData";
import { TeamContext } from "../context/TeamContext";

// Custom hook to be able to use state
function useTeams() {
  const context = useContext(TeamContext);
  if (context === undefined) {
    throw new Error("useTeam must be used within a TeamProvider");
  }
  return context;
}

function TeamProvider(props: { children: React.ReactNode }) {
  const [teams, setTeams] = useState<TeamData[]>([]);
  const [players, setPlayers] = useState<PlayerData[]>([]);
  const [loadingPlayers, setLoadingPlayers] = useState(false);
  const [loadingTeams, setLoadingTeams] = useState(false);

  const getTeams = async () => {
    setLoadingTeams(true);
    await TeamApi.getTeams()
      .then((res) => setTeams(res))
      .catch((err) => console.log(err))
      .finally(() => setLoadingTeams(false));
  };

  const getPlayers = async () => {
    setLoadingPlayers(true);
    await PlayersApi.getPlayers()
      .then((res) => setPlayers(res))
      .catch((err) => console.log(err))
      .finally(() => setLoadingPlayers(false));
  };

  useEffect(() => {
    getTeams();
    getPlayers();
  }, []);

  return (
    <TeamContext.Provider
      value={{
        teams,
        players,
        loadingTeams,
        loadingPlayers,
      }}
    >
      {props.children}
    </TeamContext.Provider>
  );
}

export { TeamProvider, useTeams };
