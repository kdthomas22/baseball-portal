import { PlayerData } from "../models/PlayerData"
import { PlayerStats } from "../models/PlayerStats"
import HttpUtility from "./config/HttpUtility"

class PlayersApi {

    private static readonly baseUrl: string = 'http://localhost:5000/Player'

    public getPlayerDetails = async (playerId: number): Promise<PlayerData> => {
        const endpoint = `${PlayersApi.baseUrl}/${playerId}`
        const result = await HttpUtility.get<PlayerData>(endpoint)
        return result.data
    }

    public getPlayerStats = async (playerId: number, yearId: number) : Promise<PlayerStats> => {
        const endpoint = `${PlayersApi.baseUrl}/stats/${playerId}/${yearId}`
        const result = await HttpUtility.get<PlayerStats>(endpoint)
        return result.data
    }

}

export default new PlayersApi()