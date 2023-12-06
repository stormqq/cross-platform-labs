import { useEffect } from "react";
import LoginButton from "../components/LoginButton";
import { useAuth0 } from "@auth0/auth0-react";
import { Box, List, ListItem } from "@mui/material";
import { Link } from "react-router-dom";

const HomePage = () => {
  const { user, isAuthenticated } = useAuth0();

  useEffect(() => {
    console.log(user);
  }, [user]);
  return (
    <Box sx={{
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
        justifyContent: 'center',
    }}>
      <h1>Лабораторна робота №13</h1>
      {!isAuthenticated ? (
        <List sx={{
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center',
            justifyContent: 'center',
            '& > *': {
                m: 1,
                width: '25ch',
            },
        }}>
            <ListItem>
                <Link to="/lab1">Лабораторна робота №1</Link>
            </ListItem>
            <ListItem>
                <Link href="/lab2">Лабораторна робота №2</Link>
            </ListItem>
            <ListItem>
                <Link href="/lab3">Лабораторна робота №3</Link>
            </ListItem>
        </List>
      ) : (
        <>
        <p>Авторизуйтесь, щоб переглядати підпрограми</p>
        <LoginButton />
        </>
      )}
    </Box>
  );
};
export default HomePage;
