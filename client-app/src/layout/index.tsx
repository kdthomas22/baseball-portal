import AppRouter from "../router/AppRouter";
import { ThemeProvider, createTheme, Button } from "@material-ui/core";
import { useHistory } from "react-router";
import Search from "./components/Search";

const Layout = () => {
  const history = useHistory();
  const theme = createTheme({
    typography: {
      fontFamily: "Oswald",
    },
  });
  return (
    <>
      <ThemeProvider theme={theme}>
        <Button onClick={() => history.push("/")}>Home</Button>
        <Search />
        <AppRouter />
      </ThemeProvider>
    </>
  );
};

export default Layout;
