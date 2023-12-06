import { useAuth0 } from "@auth0/auth0-react";
import LogoutButton from "../components/LogoutButton";

const UserProfile = () => {
  const { user, isAuthenticated, isLoading } = useAuth0();

  if (isLoading) {
    return <div>Loading ...</div>;
  }

  return (
    isAuthenticated && (
      <div>
        <img src={user.picture} alt={user.name} />
        <h2>{user.fullname}</h2>
        <p>{user.nickname}</p>
        <p>{user.email}</p>
        <p>{user.phone}</p>
        <LogoutButton />
      </div>
    )
  );
};

export default UserProfile;