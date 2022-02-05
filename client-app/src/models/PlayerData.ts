import { TeamData } from "./TeamData";

export interface PlayerData {
    playerid: number;
    lastname: string;
    firstname: string;
    usesname: string;
    bats: number;
    throws: number;
    teamid: number | null;
    birthdate: string | null;
    birthcity: string;
    birthcountry: string;
    birthstate: string;
    height: number | null;
    weight: number | null;
    position: number;
    number: number | null;
    headshoturl: string;
    team: TeamData
}