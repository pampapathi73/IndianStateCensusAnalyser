using NUnit.Framework;
using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.DTO;
using System.Collections.Generic;
using static IndianStateCensusAnalyser.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCensusFilePath = @"C:\Users\Pampapathi K\Desktop\Pampapathi\IndianStateCensusAnalyser\CensusAnalyserTest\Utility\IndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"C:\Users\Prashik Jaware\source\repos\DesignPrinciples\Indian-State-Census-Analyzer\CensusAnalyserTest\CsvFiles\WrongIndiaStateCensusData.csv";
        static string IndianStateCensusFilePathWithWrongDelimeter = @"C:\Users\Pampapathi K\Desktop\Pampapathi\IndianStateCensusAnalyser\CensusAnalyserTest\Utility\DelimiterIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFileType = @"C:\Users\Pampapathi K\Desktop\Pampapathi\IndianStateCensusAnalyser\CensusAnalyserTest\Utility\IndiaStateCensusData.txt";
        static string IndianStateCensusFilePathWithWrongHeader = @"C:\Users\Pampapathi K\Desktop\Pampapathi\IndianStateCensusAnalyser\CensusAnalyserTest\Utility\WrongIndiaStateCensusData.csv";
        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
        }
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);

        }
        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFileType, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }
        [Test]
        public void GivenIndianCensusDataFile_WhenWrongDelimeter_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(IndianStateCensusFilePathWithWrongDelimeter, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }
        [Test]
        public void GivenIndianCensusDataFile_WhenWrongHeader_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(IndianStateCensusFilePathWithWrongHeader, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }
    }
}