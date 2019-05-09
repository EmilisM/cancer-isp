import React from "react";
import "./Profile.css";
import { Card, Row, Col, Form, ListGroup, ListGroupItem } from "react-bootstrap";
import { Link } from "react-router-dom";

function ProfileInfoCard() {
    return (
        <Card>
            <Card.Header>
                User info
            </Card.Header>
            <Card.Body>
                <Form.Group>
                    <Form.Label>Username</Form.Label>
                    <br/>
                    <Form.Label>Admin</Form.Label>
                </Form.Group>
                <Form.Group>
                    <Form.Label>First name</Form.Label>
                    <br/>
                    <Form.Label>First name</Form.Label>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Last name</Form.Label>
                    <br/>
                    <Form.Label>Last name</Form.Label>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Registration date</Form.Label>
                    <br/>
                    <Form.Label>Registration date</Form.Label>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Description</Form.Label>
                    <br/>
                    <Form.Label>Description</Form.Label>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Birthdate</Form.Label>
                    <br/>
                    <Form.Label>yyyy-MM-dd</Form.Label>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Email</Form.Label>
                    <br/>
                    <Form.Label>Email</Form.Label>
                </Form.Group>
            </Card.Body>
        </Card>
    );
}

function RatingCard() {
    return (
        <Card>
            <Card.Header>
                User Ratings
            </Card.Header>
            <ListGroup className="list-group-flush">
                <ListGroupItem>Cras justo odio</ListGroupItem>
                <ListGroupItem>Dapibus ac facilisis in</ListGroupItem>
                <ListGroupItem>Vestibulum at eros</ListGroupItem>
            </ListGroup>
            <Card.Body>
                <Card.Link href="#">Next</Card.Link>
                <Card.Link href="#">Previous</Card.Link>
            </Card.Body>
        </Card>
    );
}

function UserLists() {
    return (
        <Card>
            <Card.Header>
                User Lists
            </Card.Header>
            <ListGroup className="list-group-flush">
                <ListGroupItem>Cras justo odio</ListGroupItem>
                <ListGroupItem>Dapibus ac facilisis in</ListGroupItem>
                <ListGroupItem>Vestibulum at eros</ListGroupItem>
            </ListGroup>
            <Card.Body>
                <Card.Link href="#">Next</Card.Link>
                <Card.Link href="#">Previous</Card.Link>
                <Card.Link>
                    <Link to="/profile/create/list">Crate new list</Link>
                </Card.Link>
            </Card.Body>
        </Card>
    );
}

function Profile() {
    return (
        <Row>
            <Col>

                <Row>
                    <Col>
                        <ProfileInfoCard/>
                    </Col>
                </Row>

            </Col>
            <Col>

                <Row>
                    <Col>
                        <RatingCard/>
                    </Col>
                </Row>

                <Row>
                    <Col>
                        <UserLists/>
                    </Col>
                </Row>

            </Col>
        </Row>
    );
}

export default Profile;