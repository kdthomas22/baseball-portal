import {
  Container,
  Divider,
  List,
  ListItem,
  ListItemText,
  ListSubheader,
} from "@material-ui/core";
import { useEffect, useState } from "react";
import PlayersApi from "../../api/PlayersApi";
import { PlayerData } from "../../models/PlayerData";
import { PlayerStats } from "../../models/PlayerStats";
import { getRoundedEra } from "../../utils/getRoundedEra";

interface Props {
  year: number;
  playerId: number;
  player: PlayerData;
}

const Stats = ({ year, playerId, player }: Props) => {
  const [loading, setLoading] = useState(false);
  const [stats, setStats] = useState<PlayerStats>();
  const isHitter = player.position >= 2 && player.position <= 10;
  const isPitcher =
    player.position === 1 || player.position === 11 || player.position === 12;

  const getStats = (playerId: number, year: number) => {
    setLoading(true);
    PlayersApi.getPlayerStats(playerId, year)
      .then((res) => setStats(res))
      .catch((err) => console.log(err))
      .finally(() => setLoading(false));
  };

  useEffect(() => {
    getStats(playerId, year);
  }, [year]);

  return (
    <Container>
      {stats &&
        (isHitter ? (
          <List>
            <ListItem>
              <ListSubheader>Games</ListSubheader>
              <ListItemText primary={stats?.g} />
            </ListItem>
            <Divider />
            <ListItem>
              <ListSubheader>AB</ListSubheader>
              <ListItemText primary={stats?.ab} />
            </ListItem>
            <Divider />
            <ListItem>
              <ListSubheader>Hits</ListSubheader>
              <ListItemText primary={stats?.hits} />
            </ListItem>
            <Divider />
            <ListItem>
              <ListSubheader>SO</ListSubheader>
              <ListItemText primary={stats?.so} />
            </ListItem>
            <Divider />
            <ListItem>
              <ListSubheader>Walks</ListSubheader>
              <ListItemText primary={stats?.ibb! + stats?.ubb!} />
            </ListItem>
            <Divider />
            <ListItem>
              <ListSubheader>AVG</ListSubheader>
              <ListItemText primary={stats?.avg} />
            </ListItem>
            <Divider />
            <ListItem>
              <ListSubheader>OBP</ListSubheader>
              <ListItemText primary={getRoundedEra(stats?.obp!)} />
            </ListItem>
            <Divider />
            <ListItem>
              <ListSubheader>SLG</ListSubheader>
              <ListItemText primary={getRoundedEra(stats?.slg)} />
            </ListItem>
            <Divider />
            <ListItem>
              <ListSubheader>OPS</ListSubheader>
              <ListItemText primary={getRoundedEra(stats?.ops)} />
            </ListItem>
            <Divider />
          </List>
        ) : (
          <List>
            <ListItem>
              <ListSubheader>Games</ListSubheader>
              <ListItemText primary={stats?.g} />
            </ListItem>
            <Divider />
            <ListItem>
              <ListSubheader>GS</ListSubheader>
              <ListItemText primary={stats?.gs} />
            </ListItem>
            <Divider />
            <ListItem>
              <ListSubheader>Wins</ListSubheader>
              <ListItemText primary={stats?.w} />
            </ListItem>
            <Divider />
            <ListItem>
              <ListSubheader>Losses</ListSubheader>
              <ListItemText primary={stats?.l} />
            </ListItem>
            <Divider />
            <ListItem>
              <ListSubheader>IP</ListSubheader>
              <ListItemText primary={stats?.inningsPitched} />
            </ListItem>
            <Divider />
            <ListItem>
              <ListSubheader>Hits</ListSubheader>
              <ListItemText primary={stats?.hits} />
            </ListItem>
            <Divider />
            <ListItem>
              <ListSubheader>SO</ListSubheader>
              <ListItemText primary={stats?.so} />
            </ListItem>
            <Divider />
            <ListItem>
              <ListSubheader>Walks</ListSubheader>
              <ListItemText primary={stats?.ibb! + stats?.ubb!} />
            </ListItem>
            <Divider />
            <ListItem>
              <ListSubheader>ERA</ListSubheader>
              <ListItemText primary={getRoundedEra(stats?.era!)} />
            </ListItem>
            <Divider />
          </List>
        ))}
      )
    </Container>
  );
};

export default Stats;
