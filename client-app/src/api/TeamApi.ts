import { TeamData } from "../models/TeamData"
import HttpUtility from "./config/HttpUtility"

class TeamApi {
    private static readonly baseUrl: string = 'http://localhost:5000/Team'

    public getTeams = async () : Promise<TeamData[]>  => {
        const endpoint = `${TeamApi.baseUrl}`
        const result = await HttpUtility.get<TeamData[]>(endpoint)
        return result.data
    }
}

export default new TeamApi()