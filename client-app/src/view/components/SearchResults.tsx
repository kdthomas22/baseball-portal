import { Card, CardContent, Container, Link, List } from "@material-ui/core";
import { useTeams } from "../../state/provider/TeamProvider";

interface Props {
  text: string;
}

const SearchResults = ({ text }: Props) => {
  const { players } = useTeams();

  const matchFound = players
    .filter(
      (p) =>
        p.firstname.toLowerCase().includes(text.toLowerCase()) ||
        p.lastname.toLowerCase().includes(text.toLowerCase())
    )
    .map((player) => (
      <div>
        <Card>
          <CardContent>{player.firstname}</CardContent>
        </Card>
      </div>
    ));

  return (
    <Container>
      {players
        .filter(
          (p) =>
            p.firstname.toLowerCase().includes(text.toLowerCase()) ||
            p.lastname.toLowerCase().includes(text.toLowerCase()) ||
            p.firstname
              .concat(p.lastname)
              .toLowerCase()
              .split("\\s+")
              .includes(text.toLowerCase())
        )
        .map((results, index) => {
          return index < 10 ? (
            <div>
              <Card>
                <CardContent>{results.firstname}</CardContent>
              </Card>
            </div>
          ) : null;
        })}
    </Container>
  );
};

export default SearchResults;
