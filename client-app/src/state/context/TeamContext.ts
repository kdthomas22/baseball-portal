import { createContext } from 'react'
import { TeamData } from '../../models/TeamData'

export interface ITeamContext {
  teams: TeamData[]
  loadingTeams: boolean
}

export const TeamContext = createContext<ITeamContext | undefined>(undefined)
