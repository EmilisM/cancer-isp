import React from "react";
import { Card, Row, Col } from "react-bootstrap";
import { Link } from "react-router-dom";
import { connect } from "react-redux";
import propTypes from "prop-types";

function mapStateToProps(state) {
    return {
        loggedIn: state.loggedIn
    }
}

function HomeGreetingCard(props) {
    HomeGreetingCard.propTypes = {
        loggedIn: propTypes.bool
    }

    return (
        <Card>
            <Card.Header>
                Hello!
            </Card.Header>
            <Card.Body>
                <div className="form-group">
                    Welcome to music rating site.
                </div>
                {props.loggedIn
                    ? <div></div>
                    : <div>
                          <div className="form-group">
                              <Link to="/login">To login page</Link>
                          </div>
                          <div className="form-group">
                              <Link to="/signup">To sign up page</Link>
                          </div>
                      </div>}
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

export default connect(mapStateToProps)(Home);