import AppRouter from "../router/AppRouter";
import { ThemeProvider, createTheme } from "@material-ui/core";

const Layout = () => {
  const theme = createTheme({
    typography: {
      fontFamily: "Oswald",
    },
  });
  return (
    <>
      <ThemeProvider theme={theme}>
        <AppRouter />
      </ThemeProvider>
    </>
  );
};

export default Layout;
