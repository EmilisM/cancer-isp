CREATE TABLE `artist` (
  `id` int(11) NOT NULL,
  `pseudonym` varchar(255) DEFAULT NULL,
  `full_name` varchar(255) DEFAULT NULL,
  `birthdate` date DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `occupation_start_date` date DEFAULT NULL,
  `fk_Occupationid` int(11) NOT NULL,
  `fk_Userid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `artistcreated`
--

CREATE TABLE `artistcreated` (
  `fk_ArtistWorkid` int(11) NOT NULL DEFAULT '0',
  `fk_Artistid` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `artistwork`
--

CREATE TABLE `artistwork` (
  `id` int(11) NOT NULL,
  `name` varchar(255) DEFAULT NULL,
  `creation_date` date DEFAULT NULL,
  `length_in_seconds` int(11) DEFAULT NULL,
  `record_label` varchar(255) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `publish_date` date DEFAULT NULL,
  `fk_Userid` int(11) NOT NULL,
  `fk_Imageid` int(11) NOT NULL,
  `fK_Genreid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `comment`
--

CREATE TABLE `comment` (
  `id` int(11) NOT NULL,
  `comment` varchar(255) DEFAULT NULL,
  `comment_date` date DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  `fk_Artistid` int(11) NOT NULL,
  `fk_Userid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `genre`
--

CREATE TABLE `genre` (
  `id` int(11) NOT NULL,
  `name` varchar(255) DEFAULT NULL,
  `year_of_discovery` date DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `fk_WorkTypeid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `image`
--

CREATE TABLE `image` (
  `id` int(11) NOT NULL,
  `photographer` varchar(255) DEFAULT NULL,
  `image_date` date DEFAULT NULL,
  `image_url` varchar(255) DEFAULT NULL,
  `image_name` varchar(255) DEFAULT NULL,
  `fk_Artistid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `occupation`
--

CREATE TABLE `occupation` (
  `id` int(11) NOT NULL,
  `name` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `rating`
--

CREATE TABLE `rating` (
  `id` int(11) NOT NULL,
  `score` decimal(10,0) DEFAULT NULL,
  `date` date DEFAULT NULL,
  `comment` varchar(255) DEFAULT NULL,
  `fk_Userid` int(11) NOT NULL,
  `fk_ArtistWorkid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `statistic`
--

CREATE TABLE `statistic` (
  `id` int(11) NOT NULL,
  `name` varchar(255) DEFAULT NULL,
  `fk_Ratingid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `id` int(11) NOT NULL,
  `username` varchar(255) DEFAULT NULL,
  `registration_date` date DEFAULT NULL,
  `password_hash` varchar(255) DEFAULT NULL,
  `password_salt` varchar(255) DEFAULT NULL,
  `karma_points` int(11) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `user_state` varchar(255) DEFAULT NULL,
  `fk_UserRoleid` int(11) NOT NULL,
  `fk_UserProfileInfoid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`id`, `username`, `registration_date`, `password_hash`, `password_salt`, `karma_points`, `email`, `user_state`, `fk_UserRoleid`, `fk_UserProfileInfoid`) VALUES
(2, 'admin', '2018-11-04', 'QMZxP5g9oJsYNlF0bhdnHTNLu2shhEL4Jk9oVlMdThw=', 'oKU99p7alSuWB2z3G1NnKw==', 0, 'admin@admin.com', 'Active', 3, 1),
(3, 'test', '2018-11-29', 'RogVN4HnDMgegNpu9V0lNhzpx1lXheKFQa4NfYj0Wak=', '0Dwgb+6QHCBBevuQKGjUQA==', NULL, 'test@gmail.com', 'Active', 2, 7);

-- --------------------------------------------------------

--
-- Table structure for table `userprofileinfo`
--

CREATE TABLE `userprofileinfo` (
  `id` int(11) NOT NULL,
  `description` varchar(255) DEFAULT NULL,
  `first_name` varchar(255) DEFAULT NULL,
  `last_name` varchar(255) DEFAULT NULL,
  `birthdate` date DEFAULT NULL,
  `phone_number` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `userprofileinfo`
--

INSERT INTO `userprofileinfo` (`id`, `description`, `first_name`, `last_name`, `birthdate`, `phone_number`) VALUES
(1, 'My name is Admin.', 'Admin', 'Adminovic', '1995-01-01', '+123456789'),
(2, NULL, NULL, NULL, NULL, NULL),
(3, NULL, NULL, NULL, NULL, NULL),
(4, NULL, NULL, NULL, NULL, NULL),
(5, NULL, NULL, NULL, NULL, NULL),
(6, NULL, NULL, NULL, NULL, NULL),
(7, NULL, NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `userrole`
--

CREATE TABLE `userrole` (
  `id` int(11) NOT NULL,
  `name` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `userrole`
--

INSERT INTO `userrole` (`id`, `name`) VALUES
(1, 'Guest'),
(2, 'User'),
(3, 'Administrator');

-- --------------------------------------------------------

--
-- Table structure for table `worktype`
--

CREATE TABLE `worktype` (
  `id` int(11) NOT NULL,
  `name` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `worktype`
--

INSERT INTO `worktype` (`id`, `name`) VALUES
(1, 'Music'),
(2, 'Movie');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `artist`
--
ALTER TABLE `artist`
  ADD PRIMARY KEY (`id`),
  ADD KEY `has` (`fk_Occupationid`),
  ADD KEY `registers` (`fk_Userid`);

--
-- Indexes for table `artistcreated`
--
ALTER TABLE `artistcreated`
  ADD PRIMARY KEY (`fk_ArtistWorkid`,`fk_Artistid`),
  ADD KEY `who_is` (`fk_Artistid`);

--
-- Indexes for table `artistwork`
--
ALTER TABLE `artistwork`
  ADD PRIMARY KEY (`id`),
  ADD KEY `assigns` (`fk_Userid`),
  ADD KEY `is_preserved` (`fk_Imageid`),
  ADD KEY `is_of` (`fK_Genreid`);

--
-- Indexes for table `comment`
--
ALTER TABLE `comment`
  ADD PRIMARY KEY (`id`),
  ADD KEY `discusses` (`fk_Artistid`),
  ADD KEY `writes` (`fk_Userid`);

--
-- Indexes for table `genre`
--
ALTER TABLE `genre`
  ADD PRIMARY KEY (`id`),
  ADD KEY `has_a` (`fk_WorkTypeid`);

--
-- Indexes for table `image`
--
ALTER TABLE `image`
  ADD PRIMARY KEY (`id`),
  ADD KEY `is_captured_in` (`fk_Artistid`);

--
-- Indexes for table `occupation`
--
ALTER TABLE `occupation`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `rating`
--
ALTER TABLE `rating`
  ADD PRIMARY KEY (`id`),
  ADD KEY `evaluates` (`fk_Userid`),
  ADD KEY `appreciates` (`fk_ArtistWorkid`);

--
-- Indexes for table `statistic`
--
ALTER TABLE `statistic`
  ADD PRIMARY KEY (`id`),
  ADD KEY `evaluated` (`fk_Ratingid`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id`),
  ADD KEY `assigned` (`fk_UserRoleid`),
  ADD KEY `completes` (`fk_UserProfileInfoid`);

--
-- Indexes for table `userprofileinfo`
--
ALTER TABLE `userprofileinfo`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `userrole`
--
ALTER TABLE `userrole`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `worktype`
--
ALTER TABLE `worktype`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `artist`
--
ALTER TABLE `artist`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `artistwork`
--
ALTER TABLE `artistwork`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `comment`
--
ALTER TABLE `comment`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `genre`
--
ALTER TABLE `genre`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `image`
--
ALTER TABLE `image`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `occupation`
--
ALTER TABLE `occupation`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `rating`
--
ALTER TABLE `rating`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `statistic`
--
ALTER TABLE `statistic`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `userprofileinfo`
--
ALTER TABLE `userprofileinfo`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `userrole`
--
ALTER TABLE `userrole`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `worktype`
--
ALTER TABLE `worktype`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `artist`
--
ALTER TABLE `artist`
  ADD CONSTRAINT `has` FOREIGN KEY (`fk_Occupationid`) REFERENCES `occupation` (`id`),
  ADD CONSTRAINT `registers` FOREIGN KEY (`fk_Userid`) REFERENCES `user` (`id`);

--
-- Constraints for table `artistcreated`
--
ALTER TABLE `artistcreated`
  ADD CONSTRAINT `created` FOREIGN KEY (`fk_ArtistWorkid`) REFERENCES `artistwork` (`id`),
  ADD CONSTRAINT `who_is` FOREIGN KEY (`fk_Artistid`) REFERENCES `artist` (`id`);

--
-- Constraints for table `artistwork`
--
ALTER TABLE `artistwork`
  ADD CONSTRAINT `assigns` FOREIGN KEY (`fk_Userid`) REFERENCES `user` (`id`),
  ADD CONSTRAINT `is_of` FOREIGN KEY (`fK_Genreid`) REFERENCES `genre` (`id`),
  ADD CONSTRAINT `is_preserved` FOREIGN KEY (`fk_Imageid`) REFERENCES `image` (`id`);

--
-- Constraints for table `comment`
--
ALTER TABLE `comment`
  ADD CONSTRAINT `discusses` FOREIGN KEY (`fk_Artistid`) REFERENCES `artist` (`id`),
  ADD CONSTRAINT `writes` FOREIGN KEY (`fk_Userid`) REFERENCES `user` (`id`);

--
-- Constraints for table `genre`
--
ALTER TABLE `genre`
  ADD CONSTRAINT `has_a` FOREIGN KEY (`fk_WorkTypeid`) REFERENCES `worktype` (`id`);

--
-- Constraints for table `image`
--
ALTER TABLE `image`
  ADD CONSTRAINT `is_captured_in` FOREIGN KEY (`fk_Artistid`) REFERENCES `artist` (`id`);

--
-- Constraints for table `rating`
--
ALTER TABLE `rating`
  ADD CONSTRAINT `appreciates` FOREIGN KEY (`fk_ArtistWorkid`) REFERENCES `artistwork` (`id`),
  ADD CONSTRAINT `evaluates` FOREIGN KEY (`fk_Userid`) REFERENCES `user` (`id`);

--
-- Constraints for table `statistic`
--
ALTER TABLE `statistic`
  ADD CONSTRAINT `evaluated` FOREIGN KEY (`fk_Ratingid`) REFERENCES `rating` (`id`);

--
-- Constraints for table `user`
--
ALTER TABLE `user`
  ADD CONSTRAINT `assigned` FOREIGN KEY (`fk_UserRoleid`) REFERENCES `userrole` (`id`),
  ADD CONSTRAINT `completes` FOREIGN KEY (`fk_UserProfileInfoid`) REFERENCES `userprofileinfo` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
