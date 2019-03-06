import React from "react";
import { Card, Row, Col, Form, Button } from "react-bootstrap";

function AdminChangeRolesCard() {
    return (
        <Card>
            <Card.Header>
                Change user role
            </Card.Header>
            <Card.Body>
                <Form.Group>
                    <Form.Label>User ID</Form.Label>
                    <Form.Control type="username" placeholder="User ID"/>
                </Form.Group>
                <Form.Group>
                    <Button variant="primary" type="submit">
                        Change role
                    </Button>
                </Form.Group>
            </Card.Body>
        </Card>
    );
}

function AdminBlockingCard() {
    return (
        <Card>
            <Card.Header>
                User blocking
            </Card.Header>
            <Card.Body>
                <Form.Group>
                    <Form.Label>User ID</Form.Label>
                    <Form.Control type="username" placeholder="User ID"/>
                </Form.Group>
                <Form.Group>
                    <Button variant="primary" type="submit">
                        Block
                    </Button>
                </Form.Group>
            </Card.Body>
        </Card>
    );
}

function AdminPromotionCard() {
    return (
        <Card>
            <Card.Header>
                Promote user
            </Card.Header>
            <Card.Body>
                <Form.Group>
                    <Form.Label>User ID</Form.Label>
                    <Form.Control type="username" placeholder="User ID" />
                </Form.Group>
                <Form.Group>
                    <Button variant="primary" type="submit">
                        Promote
                    </Button>
                </Form.Group>
            </Card.Body>
        </Card>
    );
}

function Admin() {
    return (
        <Row>
            <Col>

                <Row>
                    <Col>
                        <AdminChangeRolesCard/>
                    </Col>
                </Row>

                <Row>
                    <Col>
                        <AdminPromotionCard />
                    </Col>
                </Row>

            </Col>
            <Col>

                <Row>
                    <Col>
                        <AdminBlockingCard/>
                    </Col>
                </Row>

            </Col>
        </Row>
    );
}

export default Admin;