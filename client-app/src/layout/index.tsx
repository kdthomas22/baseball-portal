import AppRouter from "../router/AppRouter";
import TopNav from "./components/TopNav";

const Layout = () => {
  return (
    <>
      <TopNav />
      <AppRouter />
    </>
  );
};

export default Layout;
