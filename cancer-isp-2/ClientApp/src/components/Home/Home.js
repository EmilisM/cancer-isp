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

function MusicRecommendationCard({ loggedIn }) {
    if (loggedIn) {
        return (
            <Row>
                <Col>
                    <Card>
                        <Card.Header>
                            Recommendation card
                        </Card.Header>
                        <Card.Body>
                            <div className="form-group">
                                Recommendations for you dear !
                            </div>
                        </Card.Body>
                    </Card>
                </Col>
            </Row>
        );
    } else return null;
}

function HomeGreetingCard({ loggedIn }) {
    HomeGreetingCard.propTypes = {
        loggedIn: propTypes.bool
    }

    return (
        <Row>
            <Col>
                <Card>
                    <Card.Header>
                        Hello !
                    </Card.Header>
                    <Card.Body>
                        <div className="form-group">
                            Welcome to music rating site.
                        </div>
                        {loggedIn
                            ? <div>
                                  <div className="form-group">
                                      <Link to="/login">To login page</Link>
                                  </div>
                                  <div className="form-group">
                                      <Link to="/signup">To sign up page</Link>
                                  </div>
                              </div>
                            : <div> </div>}
                    </Card.Body>
                </Card>
            </Col>
        </Row>
    );
}

function Home(props) {
    return (
        <Row>
            <Col>
                <HomeGreetingCard {...props}/>

                <MusicRecommendationCard {...props}/>
            </Col>
        </Row>
    );
}

export default connect(mapStateToProps)(Home);