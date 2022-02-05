import { PlayerData } from "./PlayerData";

export interface TeamDetails {
        teamid: number
        city: string
        name: string
        abbr: string
        leagueid: number | null
        players: PlayerData[]
}