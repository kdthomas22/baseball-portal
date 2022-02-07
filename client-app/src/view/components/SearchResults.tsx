import {
  Card,
  CardContent,
  Container,
  Divider,
  Link,
  List,
  ListItem,
  ListItemText,
  Paper,
} from "@material-ui/core";
import { useHistory } from "react-router";
import { useTeams } from "../../state/provider/TeamProvider";
import { getPosition } from "../../utils/getPosition";

interface Props {
  text: string;
}

const SearchResults = ({ text }: Props) => {
  const { players } = useTeams();

  const history = useHistory();

  return (
    <Container>
      <Paper variant="outlined">
        <List>
          {players
            .filter((p) =>
              p.joinedName.toLowerCase().includes(text.toLowerCase())
            )
            .map((results, index) => {
              return index < 10 ? (
                <div>
                  <ListItem
                    button
                    onClick={() => history.push(`/player/${results.playerid}`)}
                  >
                    <ListItemText
                      primary={`${results.firstname} ${results.lastname}: ${results.team.city} ${results.team.name}`}
                      secondary={getPosition(results.position)}
                    />
                  </ListItem>
                  <Divider />
                </div>
              ) : null;
            })}
        </List>
      </Paper>
    </Container>
  );
};

export default SearchResults;
