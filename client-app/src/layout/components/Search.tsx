import { createStyles, makeStyles, TextField, Theme } from "@material-ui/core";
import { useState } from "react";
import SearchResults from "../../view/components/SearchResults";

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    textField: {
      marginLeft: 40,
      marginRight: 40,
    },
  })
);

const Search = () => {
  const classes = useStyles();
  const [text, setText] = useState("");

  return (
    <>
      <form className={classes.textField} noValidate autoComplete="off">
        <TextField
          id="outlined-basic"
          variant="outlined"
          placeholder="Search for Players "
          fullWidth
          onChange={(e) => {
            setText(e.target.value);
            console.log(e.target.value);
          }}
        />
      </form>
      {text && <SearchResults text={text} />}
    </>
  );
};

export default Search;
