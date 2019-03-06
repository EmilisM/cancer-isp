import React from "react";
import { Card, Row, Col } from "react-bootstrap";
import { Link } from "react-router-dom";

function HomeGreetingCard() {
    return (
        <Card>
            <Card.Header>
                Hello!
            </Card.Header>
            <Card.Body>
                <div className="form-group">
                    Welcome to music rating site.
                </div>
                <div className="form-group">
                    <Link to="/login">To login page</Link>
                </div>
                <div className="form-group">
                    <Link to="/signup">To sign up page</Link>
                </div>
            </Card.Body>
        </Card>
    );
}

function Home() {
    return (
        <Row>
            <Col>

                <Row>
                    <Col>
                        <HomeGreetingCard/>
                    </Col>
                </Row>

            </Col>
        </Row>
    );
}

export default Home;