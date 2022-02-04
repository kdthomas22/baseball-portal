import React, { useContext, useEffect, useState } from 'react'
import TeamApi from '../../api/TeamApi'
import { TeamData } from '../../models/TeamData'
import { TeamContext } from '../context/TeamContext'

// Custom hook to be able to use state
function useTeams() {
  const context = useContext(TeamContext)
  if (context === undefined) {
    throw new Error('useTeam must be used within a TeamProvider')
  }
  return context
}

function TeamProvider(props: { children: React.ReactNode }) {
 const [teams, setTeams] = useState<TeamData[]>([])
 const [loadingTeams, setLoadingTeams] = useState(false)


  const getTeams = async () => {
    setLoadingTeams(true)
    await TeamApi.getTeams() 
                .then((res) => setTeams(res))
                .catch(err => console.log(err))
                .finally(() => setLoadingTeams(false))
  }


  useEffect(() => {
    getTeams()
  }, [])  

  return (
    <TeamContext.Provider
      value={{
        teams,
        loadingTeams
      }}
    >
      {props.children}
    </TeamContext.Provider>
  )
}

export { TeamProvider, useTeams }
