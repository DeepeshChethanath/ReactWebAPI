import React, { Component } from 'react';
import './App.css';
import { Button, Card, CardBody, CardGroup, Col, Container, Form, Input, InputGroup, InputGroupAddon, InputGroupText, Row } from 'reactstrap';
import 'bootstrap/dist/css/bootstrap.css';

class Login extends Component {
    constructor() {
        super();
        this.state = {
            Email: '',
            Password: ''
        }
        this.Password = this.Password.bind(this);
        this.Email = this.Email.bind(this);
        this.login = this.login.bind(this);
    }
    Email(event) {
        this.setState({ Email: event.target.value })
    }
    Password(event) {
        this.setState({ Password: event.target.value })
    }
    login(event) {
        debugger;
        fetch('http://localhost:59018/Api/login/Login', {
            method: 'post',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                Email: this.state.Email,
                Password: this.state.Password
            })
        }).then((Response) => Response.json())
            .then((result) => {
                console.log(result);
                if (result.Status == 'Invalid')
                    alert('Sorrrrrry !!!! Something went wrong !!!!!');
                else if (result.Status == 'WrongCredentials') {
                    alert('Invalid User, Please check Credentials.');
                } else {
                    alert('Login Successful');
                    this.props.history.push("/Dashboard");
                }
                    
            })
    }
    render() {
        return (
            <div className="app flex-row align-items-center">
                <Container>
                    <Row className="justify-content-center">
                        <Col md="9" lg="7" xl="6">
                            <CardGroup>
                                <Card className="p-2">
                                    <CardBody>
                                        <Form>
                                            <div class="row" className="mb-2 pageheading">
                                       
                                                <h3 className="text-center"><span class="badge badge-secondary">Login</span></h3>
                                            </div>
                                            <InputGroup className="mb-3">
                                                <Input type="text" onChange={this.Email} placeholder="Enter Email" />
                                            </InputGroup>
                                          <InputGroup className="mb-4">
                                                <Input type="password" onChange={this.Password} placeholder="Enter Password" />
                                            </InputGroup>
                                            <Button onClick={this.login} outline color="success" block>Login</Button>
                                        </Form>
                                    </CardBody>
                                </Card>
                            </CardGroup>
                        </Col>
                    </Row>
                </Container>
            </div>
        );
    }
}
export default Login;