import React from 'react';  
import logo from './logo.svg';  
import './App.css';  
import Login from './Login';  
import SignUp from './SignUp';  
import Dashboard from './Dashboard';  
import { BrowserRouter as Router, Switch, Route, Link } from 'react-router-dom';   
import { Navbar, NavbarBrand, Nav, NavItem } from 'reactstrap';
import 'bootstrap/dist/css/bootstrap.css';

function App() {  
  return (  
    <Router>    
      <div className="container">    
        <Navbar color="light" light expand="md">
          <NavbarBrand href="/">ReactWebApi</NavbarBrand>
            <Nav className="mr-auto" navbar>
            <NavItem>
              <Link to={'/Login'} className="nav-link">Login</Link>   
            </NavItem>
            <NavItem>
              <Link to={'/Signup'} className="nav-link">Sign Up</Link>    
            </NavItem>
            </Nav>
          </Navbar> <br />    
        <Switch>    
          <Route exact path='/Login' component={Login} />    
          <Route path='/Signup' component={SignUp} />    
        </Switch>    
        <Switch>  
        <Route path='/Dashboard' component={Dashboard} />    
        </Switch>  
      </div>    
    </Router>  
  );  
}  
export default App;