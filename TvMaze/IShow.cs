﻿using System;
using System.Collections.Generic;
using TvMaze.Domain;

namespace TvMaze {
    /// <summary>
    /// Show interface
    /// </summary>
    public interface IShow {

        /// <summary>
        /// Retreive all primary information for a given show
        /// with possible embedding of additional information.
        /// </summary>
        /// <param name="showId">Show id</param>
        /// <param name="embed">Embedded additional information</param>
        /// <returns>Show info</returns>
        Show GetShow(int showId, EmbedType? embed = null);

        /// <summary>
        /// Gets a complete list of episodes for the given show.
        /// Episodes are returned in their airing order and include
        /// full episode information.
        /// 
        /// By default, specials are not included in the list.
        /// </summary>
        /// <param name="showId">Show id</param>
        /// <param name="includeSpecials">True to include special episodes, otherwise false. Default is true.</param>
        /// <returns>Epiodes list</returns>
        IEnumerable<Episode> GetShowEpisodeList(int showId, bool includeSpecials = true);

        /// <summary>
        /// Retreive one specific episode from particular show given
        /// its season and episode number.
        /// </summary>
        /// <param name="showId">Show id</param>
        /// <param name="season">Season number</param>
        /// <param name="episodeNumber">Episode number</param>
        /// <returns>Specific episode</returns>
        Episode GetShowEpisode(int showId, int season, int episodeNumber);

        /// <summary>
        /// Retreive all episodes from particular show that have aired on a specific date.
        /// </summary>
        /// <param name="showId">Show id</param>
        /// <param name="airDate">Air date</param>
        /// <returns>List of epiodes of particular show</returns>
        IEnumerable<Episode> GetShowEpisodes(int showId, DateTime airDate);

        /// <summary>
        /// Gets a complete list of seasons for the given show.
        /// Seasons are returned in ascending order and conain the
        /// full informations that's known about them.
        /// </summary>
        /// <param name="showId">Show id</param>
        /// <returns>Coplete list of seasons for the given show</returns>
        IEnumerable<Season> GetShowSeasons(int showId);

        /// <summary>
        /// Gets a list of main cast for a show.
        /// Each cast item is a combination of a person and a character.
        /// Items are ordered by importance, which is determined by the total number of appearances of the given
        /// character in show.
        /// </summary>
        /// <param name="showId">Show id</param>
        /// <returns>List of main cast for a show</returns>
        IEnumerable<Cast> GetShowCast(int showId);

        /// <summary>
        /// A list of main crew for a show. Each crew item is a combination of a person and their crew type.
        /// </summary>
        /// <param name="showId">Show id</param>
        /// <returns>A list of main crew for a show.</returns>
        IEnumerable<Crew> GetShowCrew(int showId);

        /// <summary>
        /// Gets a list of aliases for a show.
        /// </summary>
        /// <param name="showId"></param>
        /// <returns>A list of aliases for a show</returns>
        IEnumerable<Alias> GetShowAliases(int showId);

        /// <summary>
        /// Gets a list of all shows in TvMaze database with all primary information included.
        /// List is paginated with a maximus of 250 results per call.
        /// The pagination is based on show ID, e.g. page 0 will contain
        /// shows with IDs between 0 and 250. This means a single page
        /// might contain less than 250 results in case of deletions.
        /// End of list is reachd when you receive a HTTP 404 response code.
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <returns>A list of all shows</returns>
        IEnumerable<Show> GetAllShows(int pageNumber = 0);

        /// <summary>
        /// Gets a list of all shows in the TvMaze database and the timestap when they
        /// were last updated.
        /// </summary>
        /// <returns>List of all updated shows</returns>
        IEnumerable<ShowUpdate> GetShowUpdates();

    }
}
