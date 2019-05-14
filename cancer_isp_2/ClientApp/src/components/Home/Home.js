import React from "react";
import { Card, Row, Col, ListGroup, ListGroupItem, Image } from "react-bootstrap";
import { Link } from "react-router-dom";
import { connect } from "react-redux";
import propTypes from "prop-types";

function mapStateToProps(state) {
    return {
        loggedIn: state.loggedIn
    }
}

function TopSongCard({ songs }) {
    return (
        <Row>
            <Col>
                <Card>
                    <Card.Header>
                        Top songs
                    </Card.Header>
                    <ListGroup className="list-group-flush">
                        {songs.map(song => (
                            <ListGroupItem key={song.song.id}>
                                <Row>
                                    <Col>
                                        <Image src={song.song.image.url}/>
                                        <Link to={`/song/${song.song.id}`}>
                                            {song.song.artists
                                                .map(artist => artist.artist.alias)
                                                .join(", ")} - {song.song.name}
                                        </Link>
                                    </Col>
                                    <Col align="right">
                                        {song.averageRating}
                                    </Col>
                                </Row>
                            </ListGroupItem>
                        ))}
                    </ListGroup>
                </Card>
            </Col>
        </Row>
    );
}

function MusicRecommendationCard() {
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
                            ? <div> </div>
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
            </Col>
        </Row>
    );
}

class Home extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            songs: []
        };
    }

    componentDidMount() {
        fetch("api/home/top")
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        songs: result
                    });
                });
    }

    render() {
        return (
            <div>
                <Row>
                    <Col>

                        <Row>
                            <Col>
                                <HomeGreetingCard {...this.props}/>
                            </Col>
                        </Row>

                    </Col>
                </Row>

                <Row>
                    <Col>
                        <Row>
                            <Col>
                                <TopSongCard {...this.state}/>
                            </Col>
                            <Col>
                                <MusicRecommendationCard/>
                            </Col>
                        </Row>
                    </Col>
                </Row>
            </div>
        );
    }
}

export default connect(mapStateToProps)(Home);