import { createContext } from 'react'
import { PlayerData } from '../../models/PlayerData'
import { TeamData } from '../../models/TeamData'

export interface ITeamContext {
  teams: TeamData[]
  players: PlayerData[]
  loadingTeams: boolean
  loadingPlayers: boolean
}

export const TeamContext = createContext<ITeamContext | undefined>(undefined)
