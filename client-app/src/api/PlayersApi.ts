import { PlayerData } from "../models/PlayerData"
import HttpUtility from "./config/HttpUtility"

class PlayersApi {

    private static readonly baseUrl: string = 'http://localhost:5000/Player'

    public getPlayerDetails = async (playerId: number): Promise<PlayerData> => {
        const endpoint = `${PlayersApi.baseUrl}/${playerId}`
        const result = await HttpUtility.get<PlayerData>(endpoint)
        return result.data
    }

}

export default new PlayersApi()